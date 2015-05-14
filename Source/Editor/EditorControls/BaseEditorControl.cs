using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Realm.DAL.Enumerations;
using Realm.DAL.Interfaces;
using Realm.DAL.Models;
using Realm.Edit.Builders;
using Realm.Edit.CustomControls;
using Realm.Edit.Editor;
using Realm.Edit.Properties;

namespace Realm.Edit.EditorControls
{
    public partial class BaseEditorControl : UserControl
    {
        public event EventHandler<EventArgs> DirtyChanged;

        private bool _dirty;

        private delegate void InitializeControl(BaseEditorControl aOwner, Control aControl);
        private static readonly IDictionary<Type, InitializeControl> ControlInitializers = SetupControlInitializers();

        public bool Loading { get; set; }
        public bool Copy { get; set; }
        public bool Initializing { get; set; }
        public string ControlName { get; set; }
        public SystemTypes SystemType { get; private set; }
        public int ClassId { get; private set; }
        public int Id { get; protected set; }
        public IList<Control> Changes { get; private set; }

        public BaseEditorControl()
        {
            // Ctor needed for editor
        }

        public BaseEditorControl(SystemTypes aSysType, int aClassId)
        {
            InitializeComponent();
            ControlName = "<New " + EditorFactory.Builders[aSysType].DisplayName + ">";
            ClassId = aClassId;
            SystemType = aSysType;
            Id = 0;
            Dirty = false;
            Changes = new List<Control>();
            Initializing = true;
        }

        public bool Dirty
        {
            get { return _dirty; }
            set
            {
                if (Loading) return;
                if (value == _dirty) return;

                _dirty = value;
                if (DirtyChanged != null)
                    DirtyChanged(this, new EventArgs());
            }
        }

        protected void AddChange(Control aControl)
        {
            if (!Changes.Contains(aControl))
                Changes.Add(aControl);
        }

        public virtual void InitTooltipsImpl() { }

        public void InitContent(int aId)
        {
            Cursor.Current = Cursors.WaitCursor;

            DateTime begin = DateTime.Now;
            Application.DoEvents();
            Program.MainForm.SetStatusMessage("Beginning to load " + ControlName + " [" + aId + "]");

            Loading = true;
            Id = aId;
            InitTooltipsImpl();
            InitContentImpl(aId);
            Invalidate();
            Loading = false;
            Dirty = false;

            MakeDirty();

            TimeSpan span = DateTime.Now.Subtract(begin);
            double totalSeconds = span.TotalSeconds;
            Program.MainForm.SetStatusMessage("Completed loading " + ControlName + " [" + Id + "]: " + totalSeconds + " seconds.");

            Cursor.Current = Cursors.Default;
        }

        public virtual void InitContentImpl(int aId)
        {
            throw new NotImplementedException("Unimplemented contentInitImpl()");
        }

        public void InitNew()
        {
            InitNewImpl();
            Dirty = false;
            Copy = false;
            Loading = true;
        }
        public virtual void InitNewImpl() { } // Empty initNew is ok

        public void MakeCopy()
        {
            ControlName = "Copy of " + ControlName;
            Id = 0;
            MakeDirty();
            MakeCopyImpl();
            Copy = true;
        }
        public virtual void MakeCopyImpl() { }

        public EditorBrowseInfo MakeProduct()
        {
            return MakeProductImpl();
        }

        public virtual EditorBrowseInfo MakeProductImpl()
        {
            return null;
        }

        public bool Save()
        {
            if (!IsSaveValid(true))
                return false;
            Program.MainForm.SetStatusMessage("");

            DateTime begin = DateTime.Now;
            Application.DoEvents();
            Program.MainForm.SetStatusMessage("Beginning save of " + ControlName + " [" + Id + "]");

            Cursor.Current = Cursors.WaitCursor;
            Dirty = !SaveImpl();

            if (!Dirty)
            {
                TimeSpan span = DateTime.Now.Subtract(begin);
                int totalSeconds = Convert.ToInt32(span.TotalSeconds);
                Program.Log.InfoFormat("Saving {0} [{1}]: {2} seconds.", ControlName, Id, span.TotalSeconds);
                Program.MainForm.SetStatusMessage("Completed save of " + ControlName + " [" + Id + "]: " + totalSeconds + " seconds.");
            }

            Copy = false;
            Cursor.Current = Cursors.Default;
            return !_dirty;
        }

        public virtual bool SaveImpl()
        {
            throw new NotImplementedException("Unimplemented SaveImpl()");
        }

        public virtual bool IsSaveValid(bool aGiveFeedback)
        {
            throw new NotImplementedException("Unimplemented IsSaveValid()");
        }

        public virtual bool DoesSaveHaveWarnings()
        {
            return false;
        }

        public EditorBuilder Builder
        {
            get
            {
                EditorBuilder value;
                return EditorFactory.Builders.TryGetValue(SystemType, out value)
                    ? value
                    : null;
            }
        }

        public EditorBrowseInfo BrowseInfo
        {
            get { return new EditorBrowseInfo(SystemType, Name, ClassId, Id); }
        }

        public bool IsDirty
        {
            get { return Dirty; }
        }

        public void MakeDirty()
        {
            if (Initializing) return;
            
            if (IsSaveValid(true))
                Program.MainForm.SetStatusMessage("");
            
            if (!DoesSaveHaveWarnings())
                Program.MainForm.SetStatusMessage("");

            Dirty = true;
        }

        protected void MakeDirty(object sender, EventArgs e)
        {
            MakeDirty();
        }

        private void ReValidate(object sender, EventArgs e)
        {
            IsSaveValid(true);
        }

        public virtual DialogResult PromptSave()
        {
            var promptMsg = Resources.MSG_SAVE_CHANGES_TO.Replace("{ControlName}", ControlName);
            var result = MessageBox.Show(promptMsg, Resources.MSG_SAVE_BEFORE_CLOSING, MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes) return result;
            if (!Save())
                result = DialogResult.Cancel;

            return result;
        }

        //=====================================================================
        private void OnControlAdded(object sender, ControlEventArgs e)
        {
            InitializeControlImpl(e.Control);
        }

        //=====================================================================
        private void OnLoad(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
                InitializeControlImpl(control);
        }

        //=====================================================================
        private void InitializeControlImpl(Control aControl)
        {
            InitializeControl initializerFunction;

            // Invoked the initializer function for this type of control
            var controlType = Type.GetTypeFromHandle(Type.GetTypeHandle(aControl));
            if (ControlInitializers.TryGetValue(controlType, out initializerFunction))
                initializerFunction(this, aControl);

            // Initialize children
            foreach (Control childControl in aControl.Controls)
                InitializeControlImpl(childControl);

            // Add the on control added event handler
            aControl.ControlAdded += OnControlAdded;
        }

        //=====================================================================
        private static Dictionary<Type, InitializeControl> SetupControlInitializers()
        {
            var result = new Dictionary<Type, InitializeControl>();

            var system = Assembly.GetAssembly(typeof(Form));
            var aura = Assembly.GetAssembly(typeof(AuraLinkLabel));

            result[aura.GetType("Realm.Edit.CustomControls.AuraLinkLabel")] = InitializeLinkLabel;
            result[aura.GetType("Realm.Edit.CustomControls.AuraDataGridView")] = InitializeAuraDataGridView;
            result[system.GetType("System.Windows.Forms.CheckBox")] = InitializeCheckBox;
            result[system.GetType("System.Windows.Forms.CheckedListBox")] = InitializeCheckedListBox;
            result[system.GetType("System.Windows.Forms.ComboBox")] = InitializeComboBox;
            result[system.GetType("System.Windows.Forms.NumericUpDown")] = InitializeNumericUpDown;
            result[system.GetType("System.Windows.Forms.PropertyGrid")] = InitializePropertyGrid;
            result[system.GetType("System.Windows.Forms.RadioButton")] = InitializeRadioButton;
            result[system.GetType("System.Windows.Forms.TextBox")] = InitializeTextBox;

            return result;
        }

        //=====================================================================
        private static void InitializeLinkLabel(BaseEditorControl aOwner, Control aControl)
        {
            aControl.TextChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeSequenceLinkLabel(BaseEditorControl aOwner, Control aControl)
        {
            aControl.TextChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeAuraDataGridView(BaseEditorControl aOwner, Control aControl)
        {
            var control = aControl as AuraDataGridView;
            if (control == null) return;

            control.CellValueChanged += aOwner.MakeDirty;
            control.UserDeletedRow += aOwner.MakeDirty;
            control.UserAddedRow += aOwner.MakeDirty;
            control.RowsAdded += aOwner.MakeDirty;
            control.RowsRemoved += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeCheckBox(BaseEditorControl aOwner, Control aControl)
        {
            var control = aControl as CheckBox;
            if (control == null) return;

            control.CheckedChanged += aOwner.MakeDirty;
            control.CheckStateChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeCheckedListBox(BaseEditorControl aOwner, Control aControl)
        {
            var control = aControl as CheckedListBox;
            if (control == null) return;

            control.ItemCheck += aOwner.MakeDirty;

            // These two events are work arounds for the lack of event after an item has
            // been checked in an item checkbox; in the validate caused by makeDirty, the
            // value of the CheckedItems member is outdated, and so the result of validation
            // is wrong.  This causes validation to occur after the item check event whenever
            // something could have changed the check state
            control.MouseUp += aOwner.ReValidate;
            control.KeyUp += aOwner.ReValidate;
        }

        //=====================================================================
        private static void InitializeComboBox(BaseEditorControl aOwner, Control aControl)
        {
            var control = aControl as ComboBox;
            if (control == null) return;

            control.SelectedIndexChanged += aOwner.MakeDirty;
            control.SelectedValueChanged += aOwner.MakeDirty;
            control.ValueMemberChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeNumericUpDown(BaseEditorControl aOwner, Control aControl)
        {
            var control = aControl as NumericUpDown;
            if (control == null) return;

            // This is a hack :(
            // the NumericUpDownCell class has an actual NumericUpDown control internally that it uses
            // to paint.  Every time it paints, it changes the value of the cell, marking the form as dirty
            // Clearly for these controls it is wrong to listen to the value changed event.  The only
            // method to distinguish that control is via the fact its a real NumericUpDown control whose
            // parent is an DataGridView derived class
            var system = Assembly.GetAssembly(typeof(Form));
            var dataGridView = system.GetType("System.Windows.Forms.DataGridView");
            var parentType = control.Parent.GetType();
            if (parentType.IsSubclassOf(dataGridView))
                return;

            // We have filtered out numeric up down controls we don't care about
            // perform normal initialization now
            control.ValueChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializePropertyGrid(BaseEditorControl aOwner, Control aControl)
        {
            var control = aControl as PropertyGrid;
            if (control == null) return;

            control.PropertyValueChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeRadioButton(BaseEditorControl aOwner, Control aControl)
        {
            var control = aControl as RadioButton;
            if (control == null) return;

            control.CheckedChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeTextBox(BaseEditorControl aOwner, Control aControl)
        {
            aControl.TextChanged += aOwner.MakeDirty;
        }

        //=====================================================================
        public static int SetContentLinkId(DataRowView aRow, string aCol, LinkLabel aLinkLabel)
        {
            var browseInfo = (aLinkLabel.Tag as EditorBrowseInfo);
            if (browseInfo != null && browseInfo.Id > 0)
            {
                aRow[aCol] = browseInfo.Id;
                return browseInfo.Id;
            }
            aRow[aCol] = DBNull.Value;
            return 0;
        }

        public SystemString SaveSystemString(IRealmDbContext dbContext, SystemString systemString, string value)
        {
            if (systemString == null)
            {
                var newString = new SystemString
                {
                    StringType = StringTypes.DisplayName,
                    Value = value
                };
                dbContext.SystemStrings.Add(newString);
                return newString;
            }

            var foundString = dbContext.SystemStrings.First(x => x == systemString);
            foundString.Value = value;
            return foundString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;
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

        private delegate void InitializeControl(BaseEditorControl owner, Control control);
        private static readonly IDictionary<Type, InitializeControl> ControlInitializers = SetupControlInitializers();

        public bool Loading { get; set; }
        public bool Copy { get; set; }
        public bool Initializing { get; set; }
        public string ControlName { get; protected set; }
        public SystemTypes SystemType { get; }
        public int ClassId { get; }
        public int Id { get; protected set; }
        public IList<Control> Changes { get; }

        public BaseEditorControl()
        {
            // Ctor needed for editor
        }

        public BaseEditorControl(SystemTypes systemType, int classId)
        {
            InitializeComponent();
            ControlName = $"<New {EditorFactory.Builders[systemType].DisplayName}>";
            ClassId = classId;
            SystemType = systemType;
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
                DirtyChanged?.Invoke(this, new EventArgs());
            }
        }

        protected void AddChange(Control control)
        {
            if (!Changes.Contains(control))
                Changes.Add(control);
        }

        public virtual void InitTooltipsImpl() { }

        public void InitContent(int id)
        {
            Cursor.Current = Cursors.WaitCursor;

            var begin = DateTime.Now;
            Application.DoEvents();
            Program.MainForm.SetStatusMessage($"Beginning to load {ControlName} [{id}]");

            Loading = true;
            Id = id;
            InitTooltipsImpl();
            InitContentImpl(id);
            Invalidate();
            Loading = false;
            Dirty = false;

            MakeDirty();

            var span = DateTime.Now.Subtract(begin);
            var totalSeconds = span.TotalSeconds;
            Program.MainForm.SetStatusMessage($"Completed loading {ControlName} [{Id}]: {totalSeconds} seconds.");

            Cursor.Current = Cursors.Default;
        }

        public virtual void InitContentImpl(int id)
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
            ControlName = $"Copy of {ControlName}";
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
            Program.MainForm.SetStatusMessage();

            var begin = DateTime.Now;
            Application.DoEvents();
            Program.MainForm.SetStatusMessage($"Beginning save of {ControlName} [{Id}]");

            Cursor.Current = Cursors.WaitCursor;
            Dirty = !SaveImpl();

            if (!Dirty)
            {
                var span = DateTime.Now.Subtract(begin);
                var totalSeconds = Convert.ToInt32(span.TotalSeconds);
                Program.Log.InfoFormat($"Saving {ControlName} [{Id}]: {span.TotalSeconds} seconds.");
                Program.MainForm.SetStatusMessage($"Completed save of {ControlName} [{Id}]: {totalSeconds} seconds.");
            }

            Copy = false;
            Cursor.Current = Cursors.Default;
            return !_dirty;
        }

        public virtual bool SaveImpl()
        {
            throw new NotImplementedException("Unimplemented SaveImpl()");
        }

        public virtual bool IsSaveValid(bool giveFeedback)
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

        public EditorBrowseInfo BrowseInfo => new EditorBrowseInfo(SystemType, Name, ClassId, Id);

        public bool IsDirty => Dirty;

        public void MakeDirty()
        {
            if (Initializing) return;
            
            if (IsSaveValid(true))
                Program.MainForm.SetStatusMessage();
            
            if (!DoesSaveHaveWarnings())
                Program.MainForm.SetStatusMessage();

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
        private void InitializeControlImpl(Control control)
        {
            InitializeControl initializerFunction;

            // Invoked the initializer function for this type of control
            var controlType = Type.GetTypeFromHandle(Type.GetTypeHandle(control));
            if (ControlInitializers.TryGetValue(controlType, out initializerFunction))
                initializerFunction(this, control);

            // Initialize children
            foreach (Control childControl in control.Controls)
                InitializeControlImpl(childControl);

            // Add the on control added event handler
            control.ControlAdded += OnControlAdded;
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
        private static void InitializeLinkLabel(BaseEditorControl owner, Control control)
        {
            control.TextChanged += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeSequenceLinkLabel(BaseEditorControl owner, Control control)
        {
            control.TextChanged += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeAuraDataGridView(BaseEditorControl owner, Control control)
        {
            var gridView = control as AuraDataGridView;
            if (gridView == null) return;

            gridView.CellValueChanged += owner.MakeDirty;
            gridView.UserDeletedRow += owner.MakeDirty;
            gridView.UserAddedRow += owner.MakeDirty;
            gridView.RowsAdded += owner.MakeDirty;
            gridView.RowsRemoved += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeCheckBox(BaseEditorControl owner, Control control)
        {
            var checkBox = control as CheckBox;
            if (checkBox == null) return;

            checkBox.CheckedChanged += owner.MakeDirty;
            checkBox.CheckStateChanged += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeCheckedListBox(BaseEditorControl owner, Control control)
        {
            var listBox = control as CheckedListBox;
            if (listBox == null) return;

            listBox.ItemCheck += owner.MakeDirty;

            // These two events are work arounds for the lack of event after an item has
            // been checked in an item checkbox; in the validate caused by makeDirty, the
            // value of the CheckedItems member is outdated, and so the result of validation
            // is wrong.  This causes validation to occur after the item check event whenever
            // something could have changed the check state
            listBox.MouseUp += owner.ReValidate;
            listBox.KeyUp += owner.ReValidate;
        }

        //=====================================================================
        private static void InitializeComboBox(BaseEditorControl owner, Control control)
        {
            var comboBox = control as ComboBox;
            if (comboBox == null) return;

            comboBox.SelectedIndexChanged += owner.MakeDirty;
            comboBox.SelectedValueChanged += owner.MakeDirty;
            comboBox.ValueMemberChanged += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeNumericUpDown(BaseEditorControl owner, Control control)
        {
            var numeric = control as NumericUpDown;
            if (numeric == null) return;

            // This is a hack :(
            // the NumericUpDownCell class has an actual NumericUpDown control internally that it uses
            // to paint.  Every time it paints, it changes the value of the cell, marking the form as dirty
            // Clearly for these controls it is wrong to listen to the value changed event.  The only
            // method to distinguish that control is via the fact its a real NumericUpDown control whose
            // parent is an DataGridView derived class
            var system = Assembly.GetAssembly(typeof(Form));
            var dataGridView = system.GetType("System.Windows.Forms.DataGridView");
            var parentType = numeric.Parent.GetType();
            if (parentType.IsSubclassOf(dataGridView))
                return;

            // We have filtered out numeric up down controls we don't care about
            // perform normal initialization now
            numeric.ValueChanged += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializePropertyGrid(BaseEditorControl owner, Control control)
        {
            var grid = control as PropertyGrid;
            if (grid == null) return;

            grid.PropertyValueChanged += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeRadioButton(BaseEditorControl owner, Control control)
        {
            var button = control as RadioButton;
            if (button == null) return;

            button.CheckedChanged += owner.MakeDirty;
        }

        //=====================================================================
        private static void InitializeTextBox(BaseEditorControl owner, Control control)
        {
            control.TextChanged += owner.MakeDirty;
        }

        //=====================================================================
        public static int SetContentLinkId(DataRowView row, string column, LinkLabel linkLabel)
        {
            var browseInfo = linkLabel.Tag as EditorBrowseInfo;
            if (browseInfo != null && browseInfo.Id > 0)
            {
                row[column] = browseInfo.Id;
                return browseInfo.Id;
            }
            row[column] = DBNull.Value;
            return 0;
        }
    }
}

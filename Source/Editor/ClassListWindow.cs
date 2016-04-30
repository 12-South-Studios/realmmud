using System;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Realm.DAL;
using Realm.Edit.Extensions;
using Realm.Edit.Properties;

namespace Realm.Edit
{
    public partial class ClassListWindow : Form
    {
        private readonly int _selectedClassId;

        public ClassListWindow()
        {
            InitializeComponent();
        }

        public ClassListWindow(int classId)
        {
            _selectedClassId = classId;
            InitializeComponent();
            PopulateTreeView();
        }

        private void PopulateTreeView()
        {
            trvClasses.Nodes.Clear();

            BuildSystemClassNode(null, _selectedClassId, null);
        }

        private void SetupClasses(TreeNode parentNode, int selectedClassId, int? parentClassId)
        {
            if (parentNode == null)
                throw new ArgumentNullException(nameof(parentNode), Resources.NullParameterErrorMessage);

            BuildSystemClassNode(parentNode, selectedClassId, parentClassId);
        }

        private void BuildSystemClassNode(TreeNode parentNode, int selectedClassId, int? parentClassId)
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var classList = parentClassId == null
                ? dbContext.SystemClasses.Where(x => x.ParentClassId == null)
                : dbContext.SystemClasses.Where(x => x.ParentClassId == parentClassId.Value);

            foreach (var systemClass in classList)
            {
                if (systemClass.Id == selectedClassId) continue;

                var node = parentNode.Nodes.Add("class_" + systemClass.Id, systemClass.Name);
                node.Tag = systemClass.Id;
                SetupClasses(node, selectedClassId, systemClass.Id);
            }
        }

        private void TrvClassesNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
            var sourceClass = dbContext.GetSystemClass(_selectedClassId);
            var destClass = dbContext.GetSystemClass((int)e.Node.Tag);
            if (sourceClass == null || destClass == null)
            {
                MessageBox.Show(Resources.ERR_SOURCE_OR_DEST_FOLDER_NOT_FOUND);
                return;
            }

            // Validate that the source/destination aren't the same class
            if (sourceClass == destClass)
            {
                MessageBox.Show(Resources.ERR_SOURCE_OR_DEST_FOLDER_ARE_SAME);
                return;
            }

            // Validate that the type of source/destination classes are the same
            if (sourceClass.SystemType != destClass.SystemType)
            {
                MessageBox.Show(Resources.ERR_SOURCE_OR_DEST_FOLDER_ARENT_SAME);
                return;
            }

            try
            {
                var foundClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == sourceClass.ClassId);
                var parentClass = dbContext.SystemClasses.FirstOrDefault(x => x.Id == destClass.ClassId);
                if (parentClass != null)
                    if (foundClass != null) foundClass.ParentClassId = parentClass.Id;
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                string msg = Resources.ERR_CLASS_MOVE_FAILURE
                        .Replace("{0}", sourceClass.ClassId.ToString())
                        .Replace("{1}", destClass.ClassId.ToString());

                MessageBox.Show(msg);
                Program.Log.Error(msg);  
            }
        }
    }
}
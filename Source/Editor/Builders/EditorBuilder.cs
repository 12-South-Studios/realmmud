using System;
using System.Drawing;
using System.Windows.Forms;
using Ninject;
using Realm.Admin.DAL;
using Realm.DAL;
using Realm.DAL.Enumerations;
using Realm.Edit.Editor;
using Realm.Edit.EditorControls;
using Realm.Edit.Extensions;
using Realm.Edit.Properties;

namespace Realm.Edit.Builders
{
    public abstract class EditorBuilder
    {
        public string DisplayName { get; private set; }
        public string DisplayPlural { get; private set; }
        public SystemTypes SystemType { get; private set; }
        public bool IsVisible { get; private set; }
        public Icon Icon { get; protected set; }
        public IRealmDbContext RealmContext { get; private set; }
        public IRealmAdminDbContext RealmAdminContext { get; private set; }

        protected EditorBuilder(SystemTypes aSystemType, string aDisplayName, string aDisplayPlural, 
            IRealmDbContext realmDbContext, IRealmAdminDbContext realmAdminContext)
        {
            DisplayName = aDisplayName;
            DisplayPlural = aDisplayPlural;
            SystemType = aSystemType;
            Icon = null;
            IsVisible = true;
            RealmContext = realmDbContext;
            RealmAdminContext = realmAdminContext;
        }

        protected abstract void DeleteImpl(int id);

        protected EditorBrowseInfo GetSimpleBrowseInfo(int id)
        {
            return EditorFactory.GetSimpleBrowseInfo(SystemType, id);
        }

        protected virtual int PopulateBrowseNodeImpl(TreeNode parentNode, int classId,
            ContextMenuStrip menu,
            string filter)
        {
            if (parentNode == null)
                throw new ArgumentNullException("parentNode", Resources.NullParameterErrorMessage);
            if (menu == null)
                throw new ArgumentNullException("menu", Resources.NullParameterErrorMessage);

            parentNode.RemoveNonFolderNodes();

            var systemType = RealmContext.GetSystemType(classId);

            var elementCount = 0;

            var objectList = RealmContext.GetPrimitives(systemType, classId);
            foreach (var obj in objectList)
            {
                if (!String.IsNullOrEmpty(filter) &&
                    obj.SystemName.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) == -1) continue;

                var node = parentNode.Nodes.Add("node_" + obj.Id, obj.SystemName);
                node.Tag = new EditorBrowseInfo(SystemType, obj.SystemName, classId, obj.Id);
                node.ImageKey = obj.DisplayName;
                node.SelectedImageKey = obj.DisplayName;
                
                node.ContextMenuStrip = menu;
                ++elementCount;
            }

            return elementCount;
        }

        public abstract BaseEditorControl Create(int classId);
        public abstract void Move(SystemTypes systemType, int id, int newClassId);
        public abstract string IdToText(object id);
        public abstract int PopulateBrowseNode(TreeNode parentNode, int classId, ContextMenuStrip menu, string filter);
        public abstract EditorBrowseInfo GetBrowseInfo(int id);

        public static void MoveToClass(SystemTypes systemType, int id, int newClassId)
        {
            try
            {
                IRealmDbContext dbContext = Program.NinjectKernel.Get<IRealmDbContext>();
                var obj = dbContext.GetPrimitive(systemType, id);
                if (obj == null)
                    throw new Exception();

                obj.SystemClass.ParentClassId = newClassId;
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                Program.Log.ErrorFormat("Failed to move Primitive {0} to Class {1}", id, newClassId);
            }
        }

        public virtual bool HasEditor()
        {
            return true;
        }

        public virtual bool HasCreate()
        {
            return true;
        }

        public virtual bool HasDelete()
        {
            return true;
        }

        public virtual bool HandleCustomDrag(DragEventArgs e, EditorBrowseInfo aTargetBrowseInfo, bool aSetValue)
        {
            return false;
        }

        public void Delete(int aId)
        {
            DeleteImpl(aId);
        }
    }
}

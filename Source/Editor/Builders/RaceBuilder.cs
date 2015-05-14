using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Realm.Admin.DAL.Interfaces;
using Realm.DAL.Enumerations;
using Realm.DAL.Interfaces;
using Realm.Edit.Editor;
using Realm.Edit.EditorControls;

namespace Realm.Edit.Builders
{
    public class RaceBuilder : EditorBuilder
    {
        public RaceBuilder(IRealmDbContext realmContext, IRealmAdminDbContext realmAdminContext)
            : base(SystemTypes.Race, "Race", "Races", realmContext, realmAdminContext)
        {
            Icon = Icon.FromHandle(Properties.Resources.icons_ability_16.GetHicon());
        }

        public override BaseEditorControl Create(int aClassId)
        {
            return new RaceControl(aClassId);
        }

        public override int PopulateBrowseNode(TreeNode aParentNode, int aClassId,
            ContextMenuStrip aMenu, string aFilter)
        {
            return PopulateBrowseNodeImpl(aParentNode, aClassId, aMenu, aFilter);
        }

        protected override void DeleteImpl(int aId)
        {
            try
            {
                var obj = RealmContext.Races.SingleOrDefault(x => x.Id == aId);
                if (obj == null)
                    throw new Exception();

                RealmContext.Races.Remove(obj);

                // todo delete related tables and tagset

                RealmContext.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public override void Move(SystemTypes systemType, int aId, int aNewClassId)
        {
            MoveToClass(systemType, aId, aNewClassId);
        }

        public override string IdToText(object aId)
        {
            var obj = RealmContext.Races.SingleOrDefault(x => x.Id == (int)aId);
            return obj != null ? obj.SystemName : string.Empty;
        }

        public override EditorBrowseInfo GetBrowseInfo(int aId)
        {
            return GetSimpleBrowseInfo(aId);
        }
    }
}

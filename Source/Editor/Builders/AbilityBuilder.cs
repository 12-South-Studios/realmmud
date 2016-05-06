using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Realm.Admin.DAL;
using Realm.DAL;
using Realm.DAL.Common;
using Realm.DAL.Enumerations;
using Realm.Edit.Editor;
using Realm.Edit.EditorControls;
using Realm.Edit.Properties;

namespace Realm.Edit.Builders
{
    public class AbilityBuilder : EditorBuilder
    {
        public AbilityBuilder(IRealmDbContext realmContext, IRealmAdminDbContext realmAdminContext)
            : base(SystemTypes.Ability, "Ability", "Abilities", realmContext, realmAdminContext)
        {
            Icon = Icon.FromHandle(Resources.icons_ability_16.GetHicon());
        }

        public override BaseEditorControl Create(int aClassId)
        {
            return new AbilityControl(aClassId);
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
                var obj = RealmContext.Abilities.SingleOrDefault(x => x.Id == aId);
                if (obj == null)
                    throw new ObjectNotFoundException($"Ability {aId} was not found");

                RealmContext.Abilities.Remove(obj);

                // todo delete related tables and tagset

                RealmContext.SaveChanges();
            }
            catch (ObjectNotFoundException)
            {
                
            }
        }

        public override void Move(SystemTypes systemType, int aId, int aNewClassId)
        {
            MoveToClass(systemType, aId, aNewClassId);
        }

        public override string IdToText(object aId)
        {
            var obj = RealmContext.Abilities.SingleOrDefault(x => x.Id == (int)aId);
            return obj != null ? obj.SystemName : string.Empty;
        }

        public override EditorBrowseInfo GetBrowseInfo(int aId)
        {
            return GetSimpleBrowseInfo(aId);
        }
    }
}

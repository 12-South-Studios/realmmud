using Realm.Data.Definitions;
using Realm.Library.Common;

namespace Realm.Entity.Resets
{
    /// <summary>
    ///
    /// </summary>
    public class BarrierReset : Reset
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public BarrierReset(long id, string name, Definition def)
            : base(id, name, def)
        {
            //// do nothing
        }

        protected override void OnZonePop(RealmEventArgs args)
        {
            var barrierId = ResetDef.ObjectID;

            // ResetType.Barrier
            // Does the object already exist?
            // Yes, reset its properties
        }
    }
}
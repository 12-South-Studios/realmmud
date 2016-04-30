using Realm.Data.Definitions;
using Realm.Library.Common.Events;

namespace Realm.Entity.Resets
{
    public class ContainerItemReset : Reset
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        public ContainerItemReset(long id, string name, Definition def)
            : base(id, name, def)
        {
            //// do nothing
        }

        protected override void OnZonePop(RealmEventArgs args)
        {
        }

        /*private readonly Dictionary<long, int> _items;

        public ContainerItemReset(string name, Zone zone)
            : base(Globals.Globals.ResetTypes.Container, name, zone)
        {
            _items = new Dictionary<long, int>();
        }

        public bool Closed { get; set; }
        public IEnumerable<long> Items
        {
            get { return _items.Keys; }
        }

        public int GetQuantity(long itemId)
        {
            return _items.ContainsKey(itemId) ? _items[itemId] : 0;
        }

        public void AddItem(long itemId, int qty)
        {
            Log.InfoFormat("Adding Item[{0}] to Reset[{1}]", itemId, Name);
            _items.Add(itemId, qty);
        }

        public override void Process()
        {
            // TODO: ContainerItemReset: Implement Process() call
        }*/
    }
}
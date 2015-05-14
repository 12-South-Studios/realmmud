using System;
using Realm.Data.Definitions;
using Realm.Entity;
using Realm.Library.Common;
using Realm.Library.Common.Data;

namespace Realm.Command.Test.Fakes
{
    public class FakeGameEntity : IGameEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }

        public void OnInit(DictionaryAtom initAtom)
        {
            throw new NotImplementedException();
        }

        public Definition Definition { get; set; }
        public string Description { get; set; }
        public string LongName { get; set; }
        public string PluralName { get; set; }
        public IGameEntity Location { get; set; }
        public IContext GetContext(string typeName)
        {
            throw new NotImplementedException();
        }
    }
}

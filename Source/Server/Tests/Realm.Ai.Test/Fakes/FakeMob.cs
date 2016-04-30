using System;
using Realm.Data;
using Realm.Data.Definitions;
using Realm.Entity.Entities.Interfaces;
using Realm.Entity.Interfaces;
using Realm.Library.Ai;
using Realm.Library.Common.Contexts;
using Realm.Library.Common.Data;

namespace Realm.Ai.Test.Fakes
{
    public class FakeMob : IRegularMob
    {
        public long ID { get; private set; }
        public string Name { get; private set; }
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

        public Globals.PositionTypes Position { get; set; }
        public Globals.GenderTypes Gender { get; private set; }
        public RaceDef Race { get; private set; }
        public Globals.MovementModeTypes Movement { get; set; }
        public string LastAttack { get; set; }
        public IBiota Fighting { get; set; }
        public bool IsFighting { get; private set; }
        public bool IsDead { get; private set; }
        public IAiAgent AiBrain { get; private set; }
    }
}

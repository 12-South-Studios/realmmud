//using System;
//using log4net;
//using Realm.Library.Ai;
//using Realm.Library.Common;
//using Realm.Server.Abilities;
//using Realm.Server.Ai;
//using Realm.Server.Contexts;
//using Realm.Server.Effects;
//using Realm.Server.Entities;
//using Realm.Server.NPC;
//using Realm.Server.Zones;

//namespace Realm.Server.Test.Helpers
//{
//    public class FakeMobInstance : IRegularMob
//    {
//        public LogWrapper Log { get; set; }
//        public long ID { get; set; }
//        public string Name { get; set; }
//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public IPropertyContext Properties { get; set; }
//        public IFlagContext Flags { get; set; }
//        public IBitContext Bits { get; set; }
//        public ITagContext Tags { get; set; }
//        public IContentsHandler Contents { get; set; }
//        public IMudProgHandler MudProgs { get; private set; }

//        public object GetProperty(string aName)
//        {
//            throw new NotImplementedException();
//        }

//        public string GetStringProperty(string aName)
//        {
//            throw new NotImplementedException();
//        }

//        public int GetIntProperty(string aName)
//        {
//            return Properties.GetProperty<int>(aName);
//        }

//        public bool GetBoolProperty(string aName)
//        {
//            throw new NotImplementedException();
//        }

//        public long GetLongProperty(string aName)
//        {
//            throw new NotImplementedException();
//        }

//        public double GetRealProperty(string aName)
//        {
//            throw new NotImplementedException();
//        }

//        public void OnInit()
//        {
//            throw new NotImplementedException();
//        }

//        public void OnInitHandlers()
//        {
//            throw new NotImplementedException();
//        }

//        public string Description { get; set; }
//        public string LongName { get; set; }
//        public string PluralName { get; set; }
//        public int Value { get; set; }
//        public IGameEntity Location { get; set; }
//        public Zone MyZone { get; set; }
//        public Globals.Globals.SizeTypes Size { get; set; }
//        public int Access { get; set; }
//        public bool Is(Globals.Globals.SystemTypes aType)
//        {
//            throw new NotImplementedException();
//        }

//        public bool HasMudProg(Type eventType)
//        {
//            throw new NotImplementedException();
//        }

//        public bool ExecuteMudProg(Type eventType)
//        {
//            throw new NotImplementedException();
//        }

//        public IGameTemplate Parent { get; set; }
//        public Globals.Globals.PositionTypes Position { get; set; }
//        public Globals.Globals.GenderTypes Gender { get; set; }
//        public Race Race { get; set; }
//        public Globals.Globals.MovementModeTypes Movement { get; set; }
//        public Inventory Inventory { get; set; }
//        public AbilityTemplate AutoAttackAbility { get; set; }
//        public string LastAttack { get; set; }
//        public IBiota Fighting { get; set; }
//        public bool IsFighting { get; set; }
//        public bool IsDead { get; set; }
//        public bool CanMove(string aDirection, bool isIgnoringCombat, bool aSendMessage)
//        {
//            throw new NotImplementedException();
//        }

//        public bool CanSee(GameEntityTemplate entity)
//        {
//            throw new NotImplementedException();
//        }

//        public IStatisticHandler StatisticHandler { get; set; }
//        public EffectsHandler EffectsHandler { get; set; }
//        public int Level { get; set; }
//        public int CurrentHealth { get; set; }
//        public int CurrentMana { get; set; }
//        public int CurrentStamina { get; set; }
//        public int CalculateXpAward(int playerLevel)
//        {
//            throw new NotImplementedException();
//        }

//        public IAiAgent AiBrain { get; private set; }
//        public Globals.Globals.MonsterClassTypes MonsterClass { get; private set; }
//        public Behavior Behavior { get; private set; }
//    }
//}

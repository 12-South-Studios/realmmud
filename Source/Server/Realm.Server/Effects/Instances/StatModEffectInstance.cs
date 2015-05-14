//using Realm.Server.Attributes;
//using Realm.Server.Effects.Templates;

//namespace Realm.Server.Effects.Instances
//{
//    public class StatModEffectInstance : EffectInstance
//    {
//        public StatModEffectInstance(long id, StatModEffectTemplate parent)
//            : base(id, parent)
//        {
//            var myParent = parent;
//            Value = Library.Common.Random.Between(myParent.MinValue, myParent.MaxValue);
//        }

//        public Globals.Globals.Statistics Stat
//        {
//            get { return ((StatModEffectTemplate)(Parent)).Stat; }
//        }

//        public Skill Skill
//        {
//            get { return ((StatModEffectTemplate)(Parent)).Skill; }
//        }

//        public Globals.Globals.ElementTypes Element
//        {
//            get { return ((StatModEffectTemplate)(Parent)).Element; }
//        }

//        public new int Value { get; private set; }
//    }
//}

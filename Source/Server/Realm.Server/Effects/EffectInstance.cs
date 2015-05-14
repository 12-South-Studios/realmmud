//// ----------------------------------------------------------------------
//// <copyright file="EffectInstance.cs" company="12-South Studios">
////     Copyright (c) 2012. All right reserved.  See LICENSE.TXT.  This file 
////     subject to the Microsoft Public License.  All other rights reserved.
//// </copyright>
//// <summary>
////
//// </summary>
//// ------------------------------------------------------------------------

//using Realm.Library.Common;
//using Realm.Server.Properties;

//namespace Realm.Server.Effects
//{
//    public abstract class EffectInstance : GameEntityInstance
//    {
//        protected EffectInstance(long id, EffectTemplate parent)
//            : base(parent, id)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            if (Parent.IsNotNull())
//                Flags.FlagList = Parent.Flags.FlagList;
//            var flag = (Flag)DataManager.Get("Flags", "instance");
//            if (flag.IsNull())
//            {
//                Log.ErrorFormat(ErrorResources.ERR_FLAG_NOT_FOUND, "instance");
//                return;
//            }
//            Flags.SetFlag(flag.Abbrev);

//            // TODO: : Handle the applicationText here
//        }

//        public IGameEntity Owner { get; set; }


//        public int TimeLeft
//        {
//            get { return Properties.GetProperty<int>("time_left"); }
//            set { Properties.SetProperty("time_left", value); }
//        }

//        public Globals.Globals.EffectTypes EffectType
//        {
//            get
//            {
//                var parent = Parent as EffectTemplate;
//                return parent.IsNull() ? Globals.Globals.EffectTypes.StatMod : parent.EffectType;
//            }
//        }

//        new public string Name
//        {
//            get { return Parent.IsNotNull() ? Parent.Name : string.Empty; }
//        }

//        public virtual void OnGameTick()
//        {
//            TimeLeft--;
//            Log.InfoFormat("Effect[{0}, {1}] tick. Remaining[{2}]", ID, Name, TimeLeft);
//        }
//    }
//}



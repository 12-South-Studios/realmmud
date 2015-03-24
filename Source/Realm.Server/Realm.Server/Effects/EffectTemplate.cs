//using Realm.Library.Common;
//using Realm.Server.Properties;

//namespace Realm.Server.Effects
//{
//    public abstract class EffectTemplate : GameEntityTemplate
//    {
//        protected EffectTemplate(long id, string name)
//            : base(id, name, null)
//        {
//        }

//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();
//            var flag = (Flag)DataManager.Get("Flags", "effect");
//            if (flag.IsNull())
//            {
//                Log.ErrorFormat(ErrorResources.ERR_FLAG_NOT_FOUND, "effect");
//                return;
//            }
//            Flags.SetFlag(flag.Abbrev);
//            EffectType = EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>("Base");
//        }

//        public Globals.Globals.EffectTypes EffectType
//        {
//            get
//            {
//                return EnumerationExtensions.GetEnum<Globals.Globals.EffectTypes>(Properties.GetProperty<string>("effect_type"));
//            }
//            set
//            {
//                Properties.SetProperty("effect_type", value.GetName());
//            }
//        }

//        public string ApplicationTextSelf
//        {
//            get
//            {
//                return !Properties.HasProperty("application_text_self")
//                    ? Game.Properties.GetProperty<string>("effect_application_text_self")
//                    : Properties.GetProperty<string>("application_text_self");
//            }
//            set
//            {
//                Properties.SetProperty("application_text_self", value);
//            }
//        }

//        public string ApplicationTextOther
//        {
//            get
//            {
//                return !Properties.HasProperty("application_text_other")
//                    ? Game.Properties.GetProperty<string>("effect_application_text_other")
//                    : Properties.GetProperty<string>("application_text_other");
//            }
//            set
//            {
//                Properties.SetProperty("application_text_other", value);
//            }
//        }

//        public string FadeTextSelf
//        {
//            get
//            {
//                return !Properties.HasProperty("fade_text_self")
//                    ? Game.Properties.GetProperty<string>("effect_fade_text_self")
//                    : Properties.GetProperty<string>("fade_text_self");
//            }
//            set
//            {
//                Properties.SetProperty("fade_text_self", value);
//            }
//        }

//        public string FadeTextOther
//        {
//            get
//            {
//                return !Properties.HasProperty("fade_text_other")
//                    ? Game.Properties.GetProperty<string>("effect_fade_text_other")
//                    : Properties.GetProperty<string>("fade_text_other");
//            }
//            set
//            {
//                Properties.SetProperty("fade_text_other", value);
//            }
//        }

//        public string NameMod
//        {
//            get { return Properties.GetProperty<string>("name_mod_string"); }
//            set { Properties.SetProperty("name_mod_string", value); }
//        }

//        public Globals.Globals.Statistics ResistStat
//        {
//            get { return EnumerationExtensions.GetEnum<Globals.Globals.Statistics>(Properties.GetProperty<string>("resist_stat")); }
//            set { Properties.SetProperty("resist_stat", value.GetName()); }
//        }

//        public long OnFailEffectId
//        {
//            get { return Properties.GetProperty<long>("onfail_Effect_id"); }
//            set { Properties.SetProperty("onfail_Effect_id", value); }
//        }

//        public long OnResistEffectId
//        {
//            get { return Properties.GetProperty<long>("onresist_Effect_id"); }
//            set { Properties.SetProperty("onresist_Effect_id", value); }
//        }

//        public int Duration
//        {
//            get { return Properties.GetProperty<int>("duration"); }
//            set { Properties.SetProperty("duration", value); }
//        }

//        public int ZoneLimit
//        {
//            get { return Properties.GetProperty<int>("zone_limit"); }
//            set { Properties.SetProperty("zone_limit", value); }
//        }

//        public int GlobalLimit
//        {
//            get { return Properties.GetProperty<int>("global_limit"); }
//            set { Properties.SetProperty("global_limit", value); }
//        }
//    }
//}

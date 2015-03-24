//using Realm.Library.Common;
//using Realm.Server.Events;

//// ReSharper disable CheckNamespace
//namespace Realm.Server.NPC
//// ReSharper restore CheckNamespace
//{
//    public class StaticNpcInstance : MobInstance, IStaticNpc
//    {
//        public StaticNpcInstance(long id, StaticNpcTemplate parent) : base(id, parent)
//        {
//        }

//        #region GameEntity
//        //public override void OnInit(DictionaryAtom definition)
//        public override void OnInit()
//        {
//        //    base.OnInit();

//            if (!Bits.HasBit(Globals.Globals.MobileBits.IsAnimal))
//                EventManager.RegisterListener(this, typeof(OnMobHear), MobInstance_OnMobHear);
//        }
//        #endregion

//        #region IConversationalist
//        public ConversationTree ChatTree
//        {
//            get
//            {
//                var parent = Parent as MobTemplate;
//                return parent.IsNull() ? null : parent.ChatTree;
//            }
//        }

//        public void Speak(Globals.Globals.SpeechTypes type, IBiota oTarget, string cmd, IGameEntity oObj = null)
//        {
//            // TODO: Re-Implement Mob's ability to Speak
//            /*var sb = new StringBuilder();
//            switch (type)
//            {
//                case SpeechType.Say:
//                    sb.AppendFormat("{0} {1}", oTarget.Id, cmd);

//                    var sayCmd = CommandManager.Instance.GetCommand("say");
//                    sayCmd.Execute(this, oTarget, oObj, sb.ToString(), false);
//                    break;

//                case SpeechType.Whisper:
//                    sb.AppendFormat("{0} {1}", oTarget.GetName(), cmd);
//                    Whisper.utility_command_whisper(this, oTarget, oObj, sb.ToString(), false);
//                    break;

//                default:
//                    break;
//            }*/
//        }

//        public void Emote(IBiota oTarget, string sCmd)
//        {
//            // TODO: Re-Implement Mob's ability to Emote
//            ////Emote(this, oTarget, null, sCmd, false);
//        }
//        void MobInstance_OnMobHear(RealmEventArgs e)
//        {
//            var parent = Parent as MobTemplate;
//            if (parent.IsNull()) return;

//            if (parent.ChatTree.IsNull() || parent.ChatTree.NodeCount <= 0)
//                return;

//            var node = parent.ChatTree.GetNode(e.Data["phrase"].ToString());
//            if (node.IsNull()) return;

//            var biote = e.Sender as Biota;
//            if (biote.IsNull()) return;

//            switch (biote.GetStringProperty("last command verb").ToLower())
//            {
//                case "say":
//                    this.Say(biote, node.Text);
//                    break;
//                case "whisper":
//                    this.Whisper(biote, node.Text);
//                    break;
//                case "shout":
//                    this.Shout(biote, node.Text);
//                    break;
//            }
//        }
//        #endregion
//    }
//}

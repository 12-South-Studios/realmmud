//using Realm.Library.Common;
//using Realm.Server.NPC;

//// ReSharper disable CheckNamespace
//namespace Realm.Server
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Static class containing extension functions for Mobiles
//    /// </summary>
//    public static class MobileExtensions
//    {
//        public static void Say(this IConversationalist npc, IBiota target, string text, IGameEntity obj = null)
//        {
//            Validation.IsNotNull(npc, "npc");

//            npc.Speak(Globals.Globals.SpeechTypes.Say, target, text, obj);
//        }

//        public static void Whisper(this IConversationalist npc, IBiota target, string text, IGameEntity obj = null)
//        {
//            Validation.IsNotNull(npc, "npc");

//            npc.Speak(Globals.Globals.SpeechTypes.Whisper, target, text, obj);
//        }

//        public static void Shout(this IConversationalist npc, IBiota target, string text, IGameEntity obj = null)
//        {
//            Validation.IsNotNull(npc, "npc");

//            npc.Speak(Globals.Globals.SpeechTypes.Shout, target, text, obj);
//        }

//        public static void Scream(this IConversationalist npc, IBiota target, string text, IGameEntity obj = null)
//        {
//            Validation.IsNotNull(npc, "npc");

//            npc.Speak(Globals.Globals.SpeechTypes.Scream, target, text, obj);
//        }
//    }
//}

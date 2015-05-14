//using System;
//using Realm.Library.Common;
//using Realm.Server.Players;

//// ReSharper disable CheckNamespace
//namespace Realm.Server
//// ReSharper restore CheckNamespace
//{
//    /// <summary>
//    /// Extension class that handles functions for Characters
//    /// </summary>
//    public static class CharacterExtensions
//    {
//        public static void SetBindLocation(this ICharacter character, long spaceID)
//        {
//            Validation.IsNotNull(character, "character");
//            Validation.IsNotNull(character.Properties, "character.Properties");
//            Validation.Validate<ArgumentOutOfRangeException>(spaceID >= 1 && spaceID <= Int64.MaxValue);

//            character.Properties.SetProperty("bind_location", spaceID);
//        }

//        public static void SendText(this ICharacter character, string text)
//        {
//            Validation.IsNotNull(character, "character");
//            Validation.IsNotNullOrEmpty(text, "text");

//            character.User.SendText(text);
//        }
//    }
//}

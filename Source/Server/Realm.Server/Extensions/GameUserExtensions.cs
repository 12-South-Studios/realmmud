//using Realm.Library.Common;
//using Realm.Server.Players;

//
//namespace Realm.Server
//
//{
//// ReSharper disable CSharpWarnings::CS1591
//    public static class GameUserExtensions
//// ReSharper restore CSharpWarnings::CS1591
//    {
//        /// <summary>
//        /// Gets the raw command for the user
//        /// </summary>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static string GetRawCommand(this GameUser user)
//        {
//            Validation.IsNotNull(user, "user");
//            Validation.IsNotNull(user.Properties, "user.Properties");

//            return user.GetProperty<string>("raw command");
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public static string GetLastCommand(this GameUser user)
//        {
//            Validation.IsNotNull(user, "user");
//            Validation.IsNotNull(user.Properties, "user.Properties");

//            return user.GetProperty<string>("last command string");
//        }

//        public static ICharacter GetCurrentCharacter(this GameUser user)
//        {
//            Validation.IsNotNull(user, "user");
//            Validation.IsNotNull(user.Characters, "user.Characters");

//            return user.Characters.Character;
//        }

//        #region Property Functions

//        public static T GetProperty<T>(this GameUser user, string name)
//        {
//            Validation.IsNotNull(user, "user");
//            Validation.IsNotNull(user.Properties, "user.Properties");
//            Validation.IsNotNullOrEmpty(name, "name");

//            return user.Properties.GetProperty<T>(name);
//        }

//        public static void SetProperty(this GameUser user, string name, object value, PropertyTypeOptions bits = PropertyTypeOptions.None)
//        {
//            Validation.IsNotNull(user, "user");
//            Validation.IsNotNull(user.Properties, "user.Properties");
//            Validation.IsNotNullOrEmpty(name, "name");

//            user.Properties.SetProperty(name, value, bits);
//        }

//        #endregion
//    }
//}

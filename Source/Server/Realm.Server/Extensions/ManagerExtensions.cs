//using System;
//using Realm.Entity;
//using Realm.Library.Common;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Managers;
//using Realm.Server.Properties;
//using Realm.Server.Time;
//using Realm.Time;
//using log4net;

//
//namespace Realm.Server
//
//{
//// ReSharper disable CSharpWarnings::CS1591
//    public static class ManagerExtensions
//// ReSharper restore CSharpWarnings::CS1591
//    {
//        /// <summary>
//        /// Gets a flag from the DataManager singleton with the given category.
//        /// </summary>
//        /// <exception cref="GeneralException"></exception>
//        public static Flag GetFlag(this IDataManager manager, string category, ILog log = null)
//        {
//            Validation.IsNotNull(manager, "manager");
//            Validation.IsNotNullOrEmpty(category, "category");

//            var flag = manager.Get("Flags", category);
//            var logger = log ?? LogManager.GetLogger(manager.GetType());

//            if (flag.IsNull())
//            {
//                new Exception().Handle<GeneralException>(ExceptionHandlingOptions.RecordAndThrow, logger, 
//                    ErrorResources.ERR_FLAG_NOT_FOUND, category);
//            }

//            return flag as Flag;
//        }
//    }
//}

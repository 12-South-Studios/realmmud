//using System;
//using Realm.Data.Definitions;
//using Realm.Library.Common;
//using Realm.Library.Common.Data;
//using Realm.Library.Common.Exceptions;
//using Realm.Server.Properties;

//namespace Realm.Server.Factories
//{
//    /// <summary>
//    /// Abstract class that defines a factory for game objects
//    /// </summary>
//    public abstract class GameObjectFactory : IGameObjectFactory
//    {
//        public abstract ICell CreateTemplate(string type, params object[] args);
//        public abstract ICell CreateInstance(string type, params object[] args);
//        public abstract ICell CreateConcrete(string type, params object[] args);

//        /// <summary>
//        /// Create a template of the defined types with definition
//        /// </summary>
//        /// <typeparam name="T">Type of GameEntityTemplate</typeparam>
//        /// <typeparam name="K">Type of Definition object</typeparam>
//        /// <param name="type">String type</param>
//        /// <param name="args">Constructor arguments</param>
//        /// <returns>Instantiated template object of the given type</returns>
//        /// <throws>ArgumentNullException</throws>
//        /// <throws>ArgumentException</throws>
//        /// <throws>InstantiationException</throws>
//        public virtual T CreateTemplate<T, K>(string type, params object[] args)
//            where T : GameEntityTemplate
//            where K : Definition
//        {
//            Validation.IsNotNullOrEmpty(type, "type");
//            Validation.Validate(args.Length >= 3, ErrorResources.ERR_INSUF_ARGUMENTS);
//            Validation.Validate(Convert.ToInt32(args[0]) >= 1);
//            Validation.IsNotNullOrEmpty(args[1].ToString(), "args1");

//            var id = Convert.ToInt32(args[0]);
//            var name = args[1].ToString();
//            var atom = args[2].CastAs<DictionaryAtom>();

//            var obj = Create<T>(ObjectType.Template, id, name, typeof(K).Instantiate<K>(id, name, atom));
//            if (obj.IsNull())
//                throw new InstantiationException(ErrorResources.ERR_FAIL_INSTANTIATE_TEMPLATE, GetType(), id, name);

//            return obj;
//        }

//        /// <summary>
//        ///  Create an instance of the defined type with defined parent template
//        /// </summary>
//        /// <typeparam name="T">Type of GameEntityInstance</typeparam>
//        /// <typeparam name="K">Type of IGameTemplate</typeparam>
//        /// <param name="type">String type</param>
//        /// <param name="args">Constructor arguments</param>
//        /// <returns>Instantiated instance object of the given type</returns>
//        /// <throws>ArgumentNullException</throws>
//        /// <throws>ArgumentException</throws>
//        /// <throws>InstantiationException</throws>
//        public virtual T CreateInstance<T, K>(string type, params object[] args)
//            where T : GameEntityInstance
//            where K : IGameTemplate
//        {
//            Validation.IsNotNullOrEmpty(type, "type");
//            Validation.Validate(args.Length >= 2, ErrorResources.ERR_INSUF_ARGUMENTS);
//            Validation.Validate(Convert.ToInt32(args[0]) >= 1);
//            Validation.Validate(args[1] is K);

//            var id = Convert.ToInt64(args[0]);
//            var parent = args[1].CastAs<K>();

//            var obj = Create<T>(ObjectType.Instance, id, parent);
//            if (obj.IsNull())
//                throw new InstantiationException(ErrorResources.ERR_FAIL_INSTANTIATE_INSTANCE, GetType(), id, parent.ID);

//            return obj;
//        }

//        /// <summary>
//        /// Create a concrete of the defined types with definition
//        /// </summary>
//        /// <typeparam name="T">Type of GameEntityConcrete</typeparam>
//        /// <typeparam name="K">Type of Definition object</typeparam>
//        /// <param name="type">String type</param>
//        /// <param name="args">Constructor arguments</param>
//        /// <returns>Instantiated concrete object of the given type</returns>
//        /// <throws>ArgumentNullException</throws>
//        /// <throws>ArgumentException</throws>
//        /// <throws>InstantiationException</throws>
//        public virtual T CreateConcrete<T, K>(string type, params object[] args)
//            where T : GameEntityConcrete
//            where K : Definition
//        {
//            Validation.IsNotNullOrEmpty(type, "type");
//            Validation.Validate(args.Length >= 3, ErrorResources.ERR_INSUF_ARGUMENTS);
//            Validation.Validate(Convert.ToInt32(args[0]) >= 1);
//            Validation.IsNotNullOrEmpty(args[1].ToString(), "args1");
//            Validation.IsNotNull(args[2], "args2");

//            var id = Convert.ToInt32(args[0]);
//            var name = args[1].ToString();
//            var atom = args[2].CastAs<DictionaryAtom>();

//            var obj = Create<T>(ObjectType.Concrete, id, name, typeof(K).Instantiate<K>(id, name, atom));
//            if (obj.IsNull())
//                throw new InstantiationException(ErrorResources.ERR_FAIL_INSTANTIATE_TEMPLATE, GetType(), id, name);

//            return obj;
//        }

//        private static T Create<T>(ObjectType type, params object[] args) where T : IGameEntity
//        {
//            Validation.Validate(
//                type == ObjectType.Concrete || type == ObjectType.Instance || type == ObjectType.Template,
//                ErrorResources.ERR_INVALID_OBJECT_TYPE);

//            if (type == ObjectType.Concrete || type == ObjectType.Template)
//            {
//                Validation.Validate(args.Length >= 3, ErrorResources.ERR_INSUF_ARGUMENTS);

//                return typeof(T).Instantiate<T>(Convert.ToInt32(args[0]), args[1].ToString(), args[2].CastAs<DictionaryAtom>());
//            }

//            Validation.Validate(args.Length >= 2, ErrorResources.ERR_INSUF_ARGUMENTS);

//            return typeof(T).Instantiate<T>(Convert.ToInt64(args[0]), args[1].CastAs<T>());
//        }

//        [Obsolete]
//        private T Clone<T>(T sourceObject) where T : IGameEntity
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

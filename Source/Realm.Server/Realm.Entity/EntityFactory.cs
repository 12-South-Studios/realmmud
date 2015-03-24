using System;
using System.Collections.Generic;
using System.Reflection;
using Realm.Data.Definitions;
using Realm.Entity.Events;
using Realm.Entity.Properties;
using Realm.Event;
using Realm.Library.Common;

namespace Realm.Entity
{
    /// <summary>
    ///
    /// </summary>
    public sealed class EntityFactory : Library.Common.Entity, IEntityFactory
    {
        private readonly List<Type> _types = new List<Type>();
        private readonly IEventManager _eventManager;
        private readonly IEntityRepository _repository;

        /// <summary>
        ///
        /// </summary>
        public EntityFactory(IEventManager eventManager, IEntityRepository entityRepository)
            : base(1, "EntityFactory")
        {
            _eventManager = eventManager;
            _repository = entityRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Register(Type type)
        {
            if (_types.Contains(type)) return false;
            _types.Add(type);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Create(IHelper<Type> helper, string type, params object[] args)
        {
            ValidateArgs(args);
            return CreateImpl(helper.Get(type), Convert.ToInt64(args[0]), args[1] as Definition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Create(Type type, params object[] args)
        {
            ValidateArgs(args);

            return CreateImpl(type, Convert.ToInt64(args[0]), args[1] as Definition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Create<T>(params object[] args) where T : IEntity
        {
            ValidateArgs(args);

            return (T)CreateImpl(typeof(T), Convert.ToInt64(args[0]), args[1] as Definition);
        }

        private object CreateImpl(Type type, long id, Definition definition)
        {
            object entity = null;
            try
            {
                object obj = null;
                if (_types.Contains(type))
                {
                    var ctors = type.GetConstructors(BindingFlags.Public);
                    obj = ctors[0].Invoke(new object[] { id, definition });
                }

                if (obj.IsNull())
                    throw new InstantiationException(Resources.ERR_FAIL_INSTANTIATE_OBJECT, type, id);

                entity = Convert.ChangeType(obj, type);
                if (entity.IsNull())
                    throw new InvalidCastException(string.Format(Resources.ERR_REPOSITORY_INVALID_TYPE, type));

                _repository.Add(id, entity as IEntity);
            }
            catch (Exception ex)
            {
                ex.Handle(ExceptionHandlingOptions.RecordAndThrow);
            }

            _eventManager.ThrowEvent<OnEntityCreated>(this, new EventTable
                                                                {
                                                                    {"EntityID", id },
                                                                    {"Entity", entity}
                                                                });
            return entity;
        }

        private static void ValidateArgs(params object[] args)
        {
            Validation.Validate(args.Length >= 2);
            Validation.IsNotNull(args[0], "args0");
            Validation.IsNotNull(args[1], "args1");
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Clone<T>(T source, params object[] args) where T : IEntity
        {
            throw new NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Realm.Entity.Contexts;
using Realm.Entity.Interfaces;
using Realm.Library.Common;
using Realm.Library.Common.Contexts;
using Realm.Library.Common.Data;
using Realm.Library.Common.Objects;

namespace Realm.Entity
{
    /// <summary>
    /// Extension class that handles functions for Game Entities
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Retrieves a list of strings containing type data about the
        /// given entity.
        /// </summary>
        private static IList<string> GetEntityData(this IGameEntity entity)
        {
            var type = entity.GetType();
            var outputList = type.GetFields().Select(t => t.GetValue(entity).IsNull()
                ? $" {t.Name}"
                : $" {t.Name}: {t.GetValue(entity)}").ToList();

            outputList.AddRange(type.GetProperties().Select(t => t.GetValue(entity, null).IsNull()
                ? $" {t.Name}"
                : $" {t.Name}: {t.GetValue(entity, null)}"));

            return outputList;
        }

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="entity"></param>
        /// <param name="entityManager"></param>
        /// <returns></returns>
        public static DictionaryAtom GetInitAtom(this IGameEntity entity, IEntityManager entityManager)
        {
            return entityManager.InitializationAtom;
        }

        #region Contents Functions

        public static IContentsContext GetContentsContext(this IGameEntity entity)
        {
            return entity.GetContext("IContentsContext").CastAs<IContentsContext>();
        }

        public static bool Contains(this IGameEntity entity, IGameEntity aEntity)
        {
            return entity.GetContentsContext().Contains(aEntity);
        }

        public static bool Contains(this IGameEntity entity, long aId)
        {
            return entity.GetContentsContext().Contains(aId);
        }

        public static bool Contains(this IGameEntity entity, string aName)
        {
            return entity.GetContentsContext().Contains(aName);
        }

        public static bool AddEntity(this IGameEntity entity, IGameEntity aEntity)
        {
            return entity.GetContentsContext().AddEntity(aEntity);
        }

        public static void AddEntities(this IGameEntity entity, IEnumerable<IGameEntity> entityList)
        {
            entity.GetContentsContext().AddEntities(entityList);
        }

        public static bool RemoveEntity(this IGameEntity entity, IGameEntity aEntity)
        {
            return entity.GetContentsContext().RemoveEntity(aEntity);
        }

        public static IList<IGameEntity> GetEntities(this IGameEntity entity)
        {
            return entity.GetContentsContext().Entities;
        }

        /*public static IList<IGameEntity> GetEntities(this IGameEntity entity, IGameTemplate aTemplate)
        {
            return entity.GetContentsContext().GetEntities(aTemplate);
        }*/

        public static IGameEntity GetEntity(this IGameEntity entity, long aId)
        {
            return entity.GetContentsContext().GetEntity(aId);
        }

        public static IGameEntity GetEntity(this IGameEntity entity, string aName)
        {
            return entity.GetContentsContext().GetEntity(aName);
        }

        /*public static IGameEntity GetEntity(this IGameEntity entity, IGameTemplate aTemplate)
        {
            return entity.Contents.GetEntity(aTemplate);
        }*/

        public static int Count(this IGameEntity entity)
        {
            return entity.GetContentsContext().Count;
        }

        #endregion Contents Functions

        #region Property Functions

        public static IPropertyContext GetPropertyContext(this IGameEntity entity)
        {
            return entity.GetContext("IPropertyContext").CastAs<IPropertyContext>();
        }

        public static T GetProperty<T>(this IGameEntity entity, string name)
        {
            return entity.GetPropertyContext().GetProperty<T>(name);
        }

        public static void SetProperty(this IGameEntity entity, string name, object value,
                                       PropertyTypeOptions bits = PropertyTypeOptions.None)
        {
            entity.GetPropertyContext().SetProperty(name, value, bits);
        }

        #endregion Property Functions

        #region Flag Functions

        public static IFlagContext GetFlagContext(this IGameEntity entity)
        {
            return entity.GetContext("IFlagContext").CastAs<IFlagContext>();
        }

        public static bool HasFlag(this IGameEntity entity, string aFlag)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNullOrEmpty(aFlag, "aFlag");
            Validation.IsNotNull(entity.GetFlagContext(), "entity.Flags");

            return entity.GetFlagContext().HasFlag(aFlag);
        }

        public static bool SetFlag(this IGameEntity entity, string aFlag)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNullOrEmpty(aFlag, "aFlag");
            Validation.IsNotNull(entity.GetFlagContext(), "entity.Flags");

            return entity.GetFlagContext().SetFlag(aFlag);
        }

        public static bool UnsetFlag(this IGameEntity entity, string aFlag)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNullOrEmpty(aFlag, "aFlag");
            Validation.IsNotNull(entity.GetFlagContext(), "entity.Flags");

            return entity.GetFlagContext().UnsetFlag(aFlag);
        }

        public static string GetFlags(this IGameEntity entity)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNull(entity.GetFlagContext(), "entity.Flags");

            return entity.GetFlagContext().Flags;
        }

        public static IEnumerable<string> GetFlagList(this IGameEntity entity)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNull(entity.GetFlagContext(), "entity.Flags");

            return entity.GetFlagContext().FlagList;
        }

        public static void SetFlagList(this IGameEntity entity, ICollection<string> flagList)
        {
            Validation.IsNotNull(entity, "entity");
            Validation.IsNotNull(entity.GetFlagContext(), "entity.Flags");
            Validation.IsNotNull(flagList, "flagList");
            Validation.IsNotEmpty(flagList);

            entity.GetFlagContext().FlagList = flagList;
        }

        #endregion Flag Functions

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static IBitContext GetBitContext(this IGameEntity entity)
        {
            return entity.GetContext("IBitContext").CastAs<IBitContext>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ITagContext GetTagContext(this IGameEntity entity)
        {
            return entity.GetContext("ITagContext").CastAs<ITagContext>();
        }
    }
}
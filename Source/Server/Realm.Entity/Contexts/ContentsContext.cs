using System;
using System.Collections.Generic;
using System.Linq;
using Realm.Library.Common;

namespace Realm.Entity.Contexts
{
    /// <summary>
    ///
    /// </summary>
    public sealed class ContentsContext : EntityContext<IGameEntity>, IContentsContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="parent"></param>
        public ContentsContext(IGameEntity parent)
            : base(parent)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="aName"></param>
        /// <returns></returns>
        public IGameEntity GetEntity(string aName)
        {
            try
            {
                return Entities.Single(entity => entity.CompareName(aName));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /*public IGameEntity GetEntity(IGameTemplate aTemplate)
        {
            return Entities.OfType<IGameInstance>().Select(entity => entity)
                .FirstOrDefault(instance => instance.Parent == aTemplate);
        }*/

        public new int Count
        {
            get { return Entities.Count; }
        }

        public bool Contains(string aName)
        {
            return Entities.Any(entity => entity.CompareName(aName));
        }

        public new IList<IGameEntity> Entities
        {
            get { return base.Entities; }
        }

        /*public IList<IGameEntity> GetEntities(IGameTemplate aTemplate)
        {
            return Entities.OfType<IGameInstance>().Select(entity => entity)
                .Where(instance => instance.Parent == aTemplate).Cast<IGameEntity>().ToList();
        }*/
    }
}
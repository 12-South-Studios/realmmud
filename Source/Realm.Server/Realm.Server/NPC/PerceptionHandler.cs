//using System.Collections.Generic;
//using Realm.Entity.Entities;
//using Realm.Library.Common;
//using Realm.Server.Item;
//using Realm.Server.Zones;

//namespace Realm.Server.NPC
//{
//    public class PerceptionHandler : BaseContext<IGameEntity>
//    {
//        public PerceptionHandler(IGameEntity parent, int range)
//            : base(parent)
//        {
//            PerceptionRange = range;
//        }

//        public int PerceptionRange { get; private set; }

//        /// <summary>
//        /// Gets all entities for a given Biota, including those 
//        /// within containers.
//        /// </summary>
//        private static IList<IGameEntity> GetAllEntities(Biota aBiote)
//        {
//            var perceivedList = new List<IGameEntity>();
//            foreach (var item in aBiote.Inventory.Items)
//            {
//                if (item.Contents.Count > 0)
//                    perceivedList.AddRange(item.Contents.Entities);
//                perceivedList.Add(item);
//            }
//            return perceivedList;
//        }

//        /// <summary>
//        /// Gets all entities for a given Space, including those within 
//        /// containers and those on Biota (and those in containers on Biota)
//        /// </summary>
//        private static IList<IGameEntity> GetAllEntities(Space aSpace)
//        {
//            var perceivedList = new List<IGameEntity>();
//            foreach (var entity in aSpace.Contents.Entities)
//            {
//                var instance = entity as GameEntityInstance;
//                if (instance.IsNull()) continue;
//                if (instance is Biota)
//                    perceivedList.AddRange(GetAllEntities(instance as Biota));
//                else if (instance is ItemInstance)
//                {
//                    if (instance.Contents.Count > 0)
//                        perceivedList.AddRange(instance.Contents.Entities);
//                }
//                perceivedList.Add(entity);
//            }
//            return perceivedList;
//        }

//        public IList<IGameEntity> GetPerceivedEntities()
//        {
//            var perceivedList = new List<IGameEntity>();

//            //// N = -1
//            //// Can't perceive anything
//            if (PerceptionRange == -1) return perceivedList;

//            //// N = 0
//            //// Can only perceive items I have in my possession
//            if (PerceptionRange == 0) return GetAllEntities(Owner as Biota);

//            //// N = 1
//            //// Can perceive entities on self and within Space
//            if (PerceptionRange == 1) return GetAllEntities(Owner.Location as Space);

//            //// N > 1 
//            //// Can perceive entities on self and in Spaces at a distance of N
//            // TODO: : Implement perception at a distance
//            return perceivedList;
//        }

//        public IList<IGameEntity> GetPerceivedEntities(int aPerception)
//        {
//            var perceivedList = new List<IGameEntity>();

//            //// N = -1
//            //// Can't perceive anything
//            if (PerceptionRange == -1) return perceivedList;

//            //// N = 0
//            //// Can only perceive items I have in my possession
//            if (PerceptionRange == 0) return GetAllEntities(Owner as Biota);

//            //// N = 1
//            //// Can perceive entities on self and within Space
//            if (PerceptionRange == 1) return GetAllEntities(Owner.Location as Space);

//            //// N > 1 
//            //// Can perceive entities on self and in Spaces at a distance of N
//            // TODO: : Implement perception at a distance
//            return perceivedList;
//        }
//    }
//}

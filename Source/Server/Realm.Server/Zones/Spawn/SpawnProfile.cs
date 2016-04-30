//using System.Collections.Generic;
//using Realm.Library.Common;

//
//namespace Realm.Server.Zones
//
//{
//    public class SpawnProfile : Cell
//    {
//        private readonly IList<IGameTemplate> _entitiesToSpawn;

//        public SpawnProfile(int id, string name, int min, int max, int chance)
//        {
//            ID = id;
//            Name = name;
//            MinQuantity = min;
//            MaxQuantity = max;
//            Chance = chance;
//            LastTemplateChosen = 0;
//            _entitiesToSpawn = new List<IGameTemplate>();
//        }

//        public SpawnLocation Location { get; set; }

//        private int _minQuantity;
//        public int MinQuantity
//        {
//            get { return _minQuantity; }
//            set
//            {
//                _minQuantity = value;
//                if (_minQuantity > MaxQuantity)
//                    MaxQuantity = value;
//            }
//        }
//        public int MaxQuantity { get; set; }
//        public int LastTemplateChosen { get; set; }
//        public int Chance { get; set; }
//        public int EntityCount { get { return _entitiesToSpawn.Count; } }

//        public IGameTemplate PickTemplate()
//        {
//            var templateNbr = Random.Between(1, _entitiesToSpawn.Count);
//            LastTemplateChosen = templateNbr;
//            return _entitiesToSpawn[templateNbr - 1];
//        }

//        public void AddEntity(IEntityManager entityManager, long id)
//        {
//            var entity = entityManager.LuaGetTemplate(id);
//            if (_entitiesToSpawn.Contains(entity)) return;
//            _entitiesToSpawn.Add(entity);
//        }
//    }
//}

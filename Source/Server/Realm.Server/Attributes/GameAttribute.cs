using Realm.Entity.Entities;

namespace Realm.Server.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class GameAttribute : Library.Common.Objects.Entity
    {
        protected GameAttribute(long id, string name) : base(id, name)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Biota Owner { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Rating { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int TrainingPoints { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int MaxValue { get; set; }
    }
}

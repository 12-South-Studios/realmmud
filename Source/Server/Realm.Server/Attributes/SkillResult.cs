using Realm.Data;

namespace Realm.Server.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class SkillResult
    {
        /// <summary>
        /// 
        /// </summary>
        public int Xp { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Globals.SkillTestResultTypes Result { get; set; }
    }
}

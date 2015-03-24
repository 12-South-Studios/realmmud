using Realm.Entity;

namespace Realm.Command
{
    /// <summary>
    /// The result of a target attempt
    /// </summary>
    public class TargetResult
    {
        /// <summary>
        /// Gets or sets the value of the first parameter
        /// </summary>
        public string FirstParameter { get; set; }

        /// <summary>
        /// Gets or sets the value of the second parameter
        /// </summary>
        public string SecondParameter { get; set; }

        /// <summary>
        /// Gets or sets the quantity of entities found
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the reference to the found entity
        /// </summary>
        public IGameEntity FoundEntity { get; set; }

        /// <summary>
        /// Gets or sets the reference to the location in which the entity was found
        /// </summary>
        public IGameEntity FoundEntityLocation { get; set; }

        /// <summary>
        /// Gets or sets the type of location the entity was found in
        /// </summary>
        public Globals.Globals.EntityLocationTypes FoundEntityLocationType { get; set; }
    }
}
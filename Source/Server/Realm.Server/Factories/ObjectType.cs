namespace Realm.Server.Factories
{
    /// <summary>
    /// Type of game object
    /// </summary>
    public enum ObjectType
    {
        /// <summary>
        /// Game template, can be instantiated
        /// </summary>
        Template, 
        
        /// <summary>
        /// Game instance, instantiated from a template
        /// </summary>
        Instance, 
        
        /// <summary>
        /// Game concrete, similar to a template, but cannot have an instance created
        /// </summary>
        Concrete
    }
}

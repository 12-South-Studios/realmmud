//using Realm.Data.Definitions;
//using Realm.Library.Common;

//namespace Realm.Server.Factories
//{
//    /// <summary>
//    /// Defines the contract for a factory of game objects
//    /// </summary>
//    public interface IGameObjectFactory
//    {
//        /// <summary>
//        /// Create a template of the given type with the given parameters
//        /// </summary>
//        /// <param name="type"></param>
//        /// <param name="args"></param>
//        /// <returns></returns>
//        ICell CreateTemplate(string type, params object[] args);

//        /// <summary>
//        /// Create an instance of the given type with given parameters
//        /// </summary>
//        /// <param name="type"></param>
//        /// <param name="args"></param>
//        /// <returns></returns>
//        ICell CreateInstance(string type, params object[] args);

//        /// <summary>
//        /// Create a concrete of the given type with given parameters
//        /// </summary>
//        /// <param name="type"></param>
//        /// <param name="args"></param>
//        /// <returns></returns>
//        ICell CreateConcrete(string type, params object[] args);

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
//        T CreateTemplate<T, K>(string type, params object[] args)
//            where T : GameEntityTemplate
//            where K : Definition;

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
//        T CreateInstance<T, K>(string type, params object[] args)
//            where T : GameEntityInstance
//            where K : IGameTemplate;

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
//        T CreateConcrete<T, K>(string type, params object[] args)
//            where T : GameEntityConcrete
//            where K : Definition;
//    }
//}

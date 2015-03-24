using System;

namespace Realm.Command.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IVariableHelper
    {
        /// <summary>
        ///
        /// </summary>
        void RegisterVariables();

        /// <summary>
        ///
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        Delegate GetDelegate(string var);

        /// <summary>
        /// 
        /// </summary>
        int Count { get; }
    }
}
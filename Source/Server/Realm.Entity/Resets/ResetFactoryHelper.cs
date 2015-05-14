using System;
using System.Collections.Generic;
using Realm.Library.Common;

namespace Realm.Entity.Resets
{
    /// <summary>
    ///
    /// </summary>
    public class ResetFactoryHelper : IHelper<Type>
    {
        private readonly Dictionary<string, Type> _table = new Dictionary<string, Type>
                                                                       {
                                                                           {"barrier", typeof (BarrierReset)},
                                                                           {"container item", typeof (ContainerItemReset)},
                                                                           {"effect", typeof (EffectReset)},
                                                                           {"item", typeof (ItemReset)},
                                                                           {"mobile", typeof (MobileReset)}
                                                                       };

        /// <summary>
        ///
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Type Get(string key)
        {
            return _table.ContainsKey(key) ? _table[key] : null;
        }
    }
}
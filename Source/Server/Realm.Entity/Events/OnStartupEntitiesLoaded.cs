﻿using Realm.Library.Common.Events;

namespace Realm.Entity.Events
{
    /// <summary>
    ///
    /// </summary>
    public class OnStartupEntitiesLoaded : EventBase
    {
        /// <summary>
        ///
        /// </summary>
        public OnStartupEntitiesLoaded()
        {
            Name = "OnStartupEntitiesLoaded";
        }
    }
}
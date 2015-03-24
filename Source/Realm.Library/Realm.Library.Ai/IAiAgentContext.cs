using System;
using System.Collections.Generic;

namespace Realm.Library.Ai
{
    /// <summary>
    ///
    /// </summary>
    public interface IAiAgentContext
    {
        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnAgentRegistered;

        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnAgentUnregistered;

        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnWake;

        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnSleep;

        /// <summary>
        ///
        /// </summary>
        event EventHandler<EventArgs> OnPause;

        /// <summary>
        ///
        /// </summary>
        IEnumerable<int> Buckets { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bucket"></param>
        /// <returns></returns>
        IList<IAiAgent> GetAgents(int bucket);

        /// <summary>
        ///
        /// </summary>
        bool Pause { get; set; }

        /// <summary>
        ///
        /// </summary>
        bool IsPaused { get; }

        /// <summary>
        ///
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="agent"></param>
        void Register(IAiAgent agent);

        /// <summary>
        ///
        /// </summary>
        /// <param name="agent"></param>
        void Unregister(IAiAgent agent);

        /// <summary>
        ///
        /// </summary>
        void WakeMobs();

        /// <summary>
        ///
        /// </summary>
        void SleepMobs();
    }
}
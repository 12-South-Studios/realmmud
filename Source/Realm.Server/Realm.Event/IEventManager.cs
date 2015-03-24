using System;
using Realm.Library.Common;

namespace Realm.Event
{
    /// <summary>
    ///
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="listenTo"></param>
        /// <param name="listenToEventType"></param>
        /// <param name="callback"></param>
        void RegisterListener(object listener, object listenTo, Type listenToEventType, EventCallback<RealmEventArgs> callback);

        /// <summary>
        ///
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="listenToEventType"></param>
        /// <param name="callback"></param>
        void RegisterListener(object listener, Type listenToEventType, EventCallback<RealmEventArgs> callback);

        /// <summary>
        ///
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="listenToEventType"></param>
        /// <returns></returns>
        bool IsListening(object listener, Type listenToEventType);

        /// <summary>
        ///
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="listenTo"></param>
        /// <param name="listenToEventType"></param>
        /// <returns></returns>
        bool IsListening(object listener, object listenTo, Type listenToEventType);

        /// <summary>
        ///
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="listenTo"></param>
        /// <param name="listenToEventType"></param>
        void StopListeningTo(object listener, object listenTo, Type listenToEventType);

        /// <summary>
        ///
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="listenToEventType"></param>
        void StopListening(object listener, Type listenToEventType);

        /// <summary>
        ///
        /// </summary>
        /// <param name="listener"></param>
        void StopListening(object listener);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="thrownEvent"></param>
        void ThrowEvent(object sender, IEventBase thrownEvent);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="thrownEvent"></param>
        /// <param name="args"></param>
        void ThrowEvent(object sender, IEventBase thrownEvent, RealmEventArgs args);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="thrownEvent"></param>
        /// <param name="table"></param>
        void ThrowEvent(object sender, IEventBase thrownEvent, EventTable table);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <param name="table"></param>
        void ThrowEvent<T>(object sender, EventTable table) where T : EventBase;
    }
}
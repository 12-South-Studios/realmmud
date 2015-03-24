using System;
using Realm.Event.Properties;
using Realm.Library.Common;
using Realm.Library.Common.Data;
using Realm.Library.Common.Logging;

namespace Realm.Event
{
    /// <summary>
    ///
    /// </summary>
    public sealed class EventManager : GameSingleton, IEventManager
    {
        private readonly ILogWrapper _log;
        private IEventHandler _eventHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public EventManager(ILogWrapper logger)
        {
            _log = logger;
        }

        ///  <summary>
        /// 
        ///  </summary>
        ///  <param name="initAtom"></param>
        /// <param name="eventHandler"></param>
        public void OnInit(DictionaryAtom initAtom, IEventHandler eventHandler)
        {
            Validation.IsNotNull(initAtom, "initAtom");

            _eventHandler = eventHandler;
            _log.Info(Resources.MSG_MGR_INITIALIZE);
        }

        /// <summary>
        /// Registers an object to listen to another object for a particular event
        /// and if that event is triggered to use a callback function
        /// </summary>
        public void RegisterListener(object listener, object listenTo, Type listenToEventType,
            EventCallback<RealmEventArgs> callback)
        {
            _eventHandler.RegisterListener(new EventListener(listener, listenTo, listenToEventType, callback));
            _log.InfoFormat(Resources.MSG_REGISTER_LISTENER_WITH_TARGET, listener, listenTo, listenToEventType);
        }

        /// <summary>
        /// Registers an object to listen for a particular event from any source
        /// and if that event is triggered to use a callback function
        /// </summary>
        public void RegisterListener(object listener, Type listenToEventType, EventCallback<RealmEventArgs> callback)
        {
            _eventHandler.RegisterListener(new EventListener(listener, null, listenToEventType, callback));
            _log.InfoFormat(Resources.MSG_REGISTER_LISTENER, listener, listenToEventType);
        }

        /// <summary>
        /// Is the object listening to the given event
        /// </summary>
        public bool IsListening(object listener, Type listenToEventType)
        {
            return _eventHandler.IsListening(listener, listenToEventType);
        }

        /// <summary>
        /// Is the object listening to the other object
        /// </summary>
        public bool IsListening(object listener, object listenTo, Type listenToEventType)
        {
            return _eventHandler.IsListening(listener, listenTo, listenToEventType);
        }

        /// <summary>
        /// Removes an object that was being listened to by another object for a particular event
        /// </summary>
        public void StopListeningTo(object listener, object listenTo, Type listenToEventType)
        {
            _eventHandler.StopListeningTo(listener, listenTo, listenToEventType);
        }

        /// <summary>
        /// Removes an object that was listening to a particular event
        /// </summary>
        public void StopListening(object listener, Type listenToEventType)
        {
            _eventHandler.StopListening(listener, listenToEventType);
        }

        /// <summary>
        /// Removes an object that was listening to any event
        /// </summary>
        public void StopListening(object listener)
        {
            _eventHandler.StopListening(listener);
        }

        /// <summary>
        ///  Enqueues an event onto the event queue
        /// </summary>
        public void ThrowEvent(object sender, IEventBase thrownEvent)
        {
            _log.DebugFormat("Sender [{0}] asked to throw Event [{1}].", sender.GetType(), thrownEvent.GetType());
            _eventHandler.ThrowEvent(sender, thrownEvent);
        }

        /// <summary>
        /// Overload function for enqueueing an event
        /// </summary>
        public void ThrowEvent(object sender, IEventBase thrownEvent, RealmEventArgs args)
        {
            _log.DebugFormat("Sender [{0}] asked to throw Event [{1}].", sender.GetType(), thrownEvent.GetType());
            _eventHandler.ThrowEvent(sender, thrownEvent, args);
        }

        /// <summary>
        /// Overload function for enqueueing an event
        /// </summary>
        public void ThrowEvent(object sender, IEventBase thrownEvent, EventTable table)
        {
            _log.DebugFormat("Sender [{0}] asked to throw Event [{1}].", sender.GetType(), thrownEvent.GetType());
            _eventHandler.ThrowEvent(sender, thrownEvent, table);
        }

        /// <summary>
        /// Instantiates and throws an event of the given type
        /// </summary>
        public void ThrowEvent<T>(object sender, EventTable table) where T : EventBase
        {
            _log.DebugFormat("Sender [{0}] asked to throw Event [{1}].", sender.GetType(), typeof(T));
            _eventHandler.ThrowEvent<T>(sender, table);
        }

        /// <summary>
        /// Instantiates and throws an event of the given type
        /// </summary>
        public void ThrowEvent<T>(object sender) where T : EventBase
        {
            _log.DebugFormat("Sender [{0}] asked to throw Event [{1}].", sender.GetType(), typeof(T));
            _eventHandler.ThrowEvent<T>(sender);
        }
    }
}
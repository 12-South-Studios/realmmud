using System;
using Realm.Library.Common.Events;

namespace Realm.Event
{
    public interface IEventManager
    {
        void RegisterListener(object listener, object listenTo, Type listenToEventType, EventCallback<RealmEventArgs> callback);
        void RegisterListener(object listener, Type listenToEventType, EventCallback<RealmEventArgs> callback);
        bool IsListening(object listener, Type listenToEventType);
        bool IsListening(object listener, object listenTo, Type listenToEventType);
        void StopListeningTo(object listener, object listenTo, Type listenToEventType);
        void StopListening(object listener, Type listenToEventType);
        void StopListening(object listener);
        void ThrowEvent(object sender, IEventBase thrownEvent);
        void ThrowEvent(object sender, IEventBase thrownEvent, RealmEventArgs args);
        void ThrowEvent(object sender, IEventBase thrownEvent, EventTable table);
        void ThrowEvent<T>(object sender, EventTable table) where T : EventBase;
    }
}
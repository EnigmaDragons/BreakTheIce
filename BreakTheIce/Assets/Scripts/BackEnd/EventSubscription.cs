﻿using System;

namespace Assets.Scripts.BackEnd
{
    public sealed class EventSubscription
    {
        public Type EventType { get; }
        public Action<object> OnEvent { get; }
        public object Owner { get; }

        private EventSubscription(Type eventType, Action<object> onEvent, object owner)
        {
            EventType = eventType;
            OnEvent = onEvent;
            Owner = owner;
        }

        public static EventSubscription Create<T>(Action<T> onEvent, object owner)
        {
            return new EventSubscription(typeof(T), (o) => { if (o.GetType() == typeof(T)) onEvent((T)o); }, owner);
        }
    }
}

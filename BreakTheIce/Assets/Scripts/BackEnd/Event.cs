using System;
using System.Collections.Generic;

namespace BreakTheIce.BackEnd
{
    public static class Event
    {
        private static readonly Dictionary<Type, List<Action<object>>> _messageHandlers = new Dictionary<Type, List<Action<object>>>();

        public static void Publish<TMessage>(TMessage message)
        {
            var type = typeof(TMessage);
            if (_messageHandlers.ContainsKey(type))
                foreach (var handler in _messageHandlers[type])
                    handler(message);
        }

        public static void Register<TMessage>(Action<TMessage> onMessage)
        {
            var type = typeof(TMessage);
            if (!_messageHandlers.ContainsKey(type))
                _messageHandlers[type] = new List<Action<object>>();
            _messageHandlers[type].Add(x => onMessage((TMessage)x));
        }
    }
}
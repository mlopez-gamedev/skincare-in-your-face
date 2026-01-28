using System;
using System.Collections.Generic;

namespace MiguelGameDev.Generic.Event
{
    public class EventDispatcherService
    {
        private readonly Dictionary<Type, SignalDelegate> _events;

        private static EventDispatcherService _instance;

        public static EventDispatcherService Instance {
            get {
                if (_instance == null)
                {
                    _instance = new EventDispatcherService();
                }
                return _instance;
            }
        }

        private EventDispatcherService()
        {
            _events = new Dictionary<Type, SignalDelegate>();
        }

        public void Subscribe<T>(SignalDelegate callback) where T : ISignal
        {
            var type = typeof(T);
            if (!_events.ContainsKey(type))
            {
                _events.Add(type, null);
            }

            _events[type] += callback;
        }

        public void Unsubscribe<T>(SignalDelegate callback) where T : ISignal
        {
            var type = typeof(T);
            if (_events.ContainsKey(type))
            {
                _events[type] -= callback;
            }
            
            if (_events[type] == null)
            {
                _events.Remove(type);
            }
        }

        public void Dispatch<T>(T signal) where T : ISignal
        {
            var type = typeof(T);
            if (!_events.ContainsKey(type))
                return;
            
            _events[type].Invoke(signal);
        }
    }

    public delegate void SignalDelegate(ISignal signal);
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiguelGameDev.Generic.Event
{
    public class AsyncEventDispatcherService
    {
        private readonly Dictionary<Type, HookDelegate> _events;

        private static AsyncEventDispatcherService _instance;

        public static AsyncEventDispatcherService Instance {
            get {
                if (_instance == null)
                {
                    _instance = new AsyncEventDispatcherService();
                }
                return _instance;
            }
        }

        private AsyncEventDispatcherService()
        {
            _events = new Dictionary<Type, HookDelegate>();
        }

        public void Subscribe<T>(HookDelegate callback) where T : IHook
        {
            var type = typeof(T);
            if (!_events.ContainsKey(type))
            {
                _events.Add(type, null);
            }

            _events[type] += callback;
        }

        public void Unsubscribe<T>(HookDelegate callback) where T : IHook
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

        public async Task Dispatch<T>(T signal) where T : IHook
        {
            var type = typeof(T);
            if (!_events.ContainsKey(type))
                return;
            
            await _events[type].Invoke(signal);
        }
    }

    public delegate Task HookDelegate(IHook signal);
}

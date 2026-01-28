using UnityEngine;

namespace MiguelGameDev
{
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool _destroyed = false;

        private static T _instance = null;

        public static T Instance
        {
            get
            {
                CreateInstance();
                return _instance;
            }
        }

        public static bool HasInstance => _instance != null;
        public static bool Destroyed => _destroyed;

        private static void CreateInstance()
        {
            if (!_destroyed && _instance == null)
            {
                _instance = FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }
            }
        }

        virtual protected void Awake() {
            if (_instance == null)
            {
                _instance = this as T;
            }
        }

        virtual protected void OnDestroy()
        {
            _instance = null;
            _destroyed = true;
        }

        virtual protected void OnApplicationQuit()
        {
            _instance = null;
            _destroyed = true;
        }
    }
}
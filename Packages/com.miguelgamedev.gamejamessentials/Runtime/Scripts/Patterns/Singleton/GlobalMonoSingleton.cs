using UnityEngine;

namespace MiguelGameDev
{
    public abstract class GlobalMonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static bool _destroyed = false;

        static T _instance = null;

        public static T Instance
        {
            get
            {
                CreateInstance();
                return _instance;
            }
        }

        public static bool HasInstance
        {
            get { return _instance != null; }
        }

        static void CreateInstance()
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

        virtual protected void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(_instance.gameObject);
            }
        }

        void OnApplicationQuit()
        {
            _instance = null;
            _destroyed = true;
        }
    }
}
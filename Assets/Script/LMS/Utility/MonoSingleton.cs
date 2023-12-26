using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMS.Utility
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    instance = new GameObject("@" + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                }
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                if (UseDontDestroyOnLoad()) DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected virtual bool UseDontDestroyOnLoad()
        {
            return false;
        }
    }
}


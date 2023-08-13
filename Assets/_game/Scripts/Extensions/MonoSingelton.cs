using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _game._Extentions
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
//                    Debug.LogError(typeof(T).ToString() + " is missing.");
                }

                return _instance;
            }
        }


        protected virtual void Awake()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            _instance = this as T;
            Init();
        }


        public virtual void Init()
        {
            //Debug.Log($"<color=#00FF00>INSTANCED-->> </color>" + this.GetType());
        }
    }
}
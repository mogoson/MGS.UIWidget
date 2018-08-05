/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleMonoBehaviour.cs
 *  Description  :  Define the base of single MonoBehaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.DesignPattern
{
    /// <summary>
    /// MonoBehaviour with a single instance.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    [DisallowMultipleComponent]
    public abstract class SingleMonoBehaviour<T> : MonoBehaviour where T : SingleMonoBehaviour<T>
    {
        #region Field and Property
        /// <summary>
        /// Makes this gameobject not be destroyed automatically when loading a new scene.
        /// </summary>
        [SerializeField]
        protected bool dontDestroyOnLoad = true;

        /// <summary>
        /// Instance of this MonoBehaviour.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    //Active MonoBehaviour in scene.
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        //Create agent to attach MonoBehaviour.
                        instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        DontDestroyOnLoad(instance.gameObject);
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Instance of this MonoBehaviour.
        /// </summary>
        private static T instance = null;
        #endregion

        #region Protected Method
        protected void Awake()
        {
            if (instance == null)
            {
                instance = this as T;

                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (instance != this)
                {
                    Destroy(this);
                    Debug.LogWarningFormat("Destroy the redundant instance of {0} component form {1} : " +
                        "Multi instances of {0} component in a scene is violat singleton design.", typeof(T).Name, name);
                    return;
                }
            }
            SingleAwake();
        }

        protected virtual void SingleAwake() { }
        #endregion
    }
}
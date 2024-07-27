/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIWidget.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UIWidget
{
    /// <summary>
    /// UI Widget.
    /// </summary>
    public abstract class UIWidget : MonoBehaviour, IUIWidget
    {
        /// <summary>
        /// The RectTransform attached to this GameObject.
        /// </summary>
        public RectTransform RTransform { get { return transform as RectTransform; } }

        /// <summary>
        /// Set gameObject active.
        /// </summary>
        /// <param name="isActive"></param>
        public virtual void SetActive(bool isActive = true)
        {
            gameObject.SetActive(isActive);
        }

        /// <summary>
        /// Destroy gameObject.
        /// </summary>
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIComponent.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.UGUI
{
    /// <summary>
    /// UI component.
    /// </summary>
    public abstract class UIComponent : UIBehaviour
    {
        /// <summary>
        /// The RectTransform attached to this GameObject.
        /// </summary>
        public RectTransform RectTransform { get { return transform as RectTransform; } }

        /// <summary>
        /// Toggle gameObject active.
        /// </summary>
        /// <param name="isActive"></param>
        public virtual void ToggleActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
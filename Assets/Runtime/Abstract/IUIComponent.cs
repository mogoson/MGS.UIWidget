/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIComponent.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/5
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI
{
    public interface IUIComponent
    {
        /// <summary>
        /// Enabled Behaviours are Updated, disabled Behaviours are not.
        /// </summary>
        bool enabled { set; get; }

        /// <summary>
        /// The RectTransform attached to this GameObject.
        /// </summary>
        RectTransform RTransform { get; }

        /// <summary>
        /// Toggle gameObject active.
        /// </summary>
        /// <param name="isActive"></param>
        void ToggleActive(bool isActive);
    }
}
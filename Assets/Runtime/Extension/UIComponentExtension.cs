/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIComponentExtension.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/27/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Extension for UI component.
    /// </summary>
    public static class UIComponentExtension
    {
        /// <summary>
        /// Require component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <returns></returns>
        public static T RequireComponent<T>(this GameObject go) where T : Component
        {
            var mpnt = go.GetComponent<T>();
            if (mpnt == null)
            {
                mpnt = go.AddComponent<T>();
            }
            return mpnt;
        }

        /// <summary>
        /// Require component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cpnt"></param>
        /// <returns></returns>
        public static T RequireComponent<T>(this Component cpnt) where T : Component
        {
            return RequireComponent<T>(cpnt.gameObject);
        }

        /// <summary>
        /// Require UIPointerListener component.
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static UIPointerListener RequirePointerListener(this Component rect)
        {
            return RequireComponent<UIPointerListener>(rect);
        }

        /// <summary>
        /// Require UIDragListener component.
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static UIDragListener RequireDragListener(this Component rect)
        {
            return RequireComponent<UIDragListener>(rect);
        }

        /// <summary>
        /// Require UISelectListener component.
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static UISelectListener RequireSelectListener(this Component rect)
        {
            return RequireComponent<UISelectListener>(rect);
        }

        /// <summary>
        /// Require Canvas,GraphicRaycaster,CanvasGroup component.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="overrideSorting"></param>
        /// <param name="sortingOrder"></param>
        public static void RequireCanvasRaycasterGroup(this Component rect, bool overrideSorting = true, int sortingOrder = 3000)
        {
            var canvas = RequireComponent<Canvas>(rect);
            canvas.overrideSorting = overrideSorting; //Do not working in Unity 5.6?
            canvas.sortingOrder = sortingOrder;

            RequireComponent<GraphicRaycaster>(rect);
            RequireComponent<CanvasGroup>(rect);
        }
    }
}
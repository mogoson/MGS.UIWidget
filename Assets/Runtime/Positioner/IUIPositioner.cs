/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIPositioner.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/5
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UIWidget
{
    public interface IUIPositioner : IUIWidget
    {
        #region Screen To Local Position
        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        Vector2 GetLocalPosition(Vector2 screenPoint);

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        Vector2 GetLocalPosition(Vector2 screenPoint, Vector2 offset);

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        Vector2 GetLocalPosition(Vector2 screenPoint, Vector2 offset, TextAnchor anchor);

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        void SetPosition(Vector2 screenPoint);

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        void SetPosition(Vector2 screenPoint, Vector2 offset);

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        void SetPosition(Vector2 screenPoint, Vector2 offset, TextAnchor anchor);
        #endregion

        #region Clamp Position In Parent
        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="padding"></param>
        /// <returns></returns>
        Vector3 GetLocalPosition(RectOffset padding);

        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        Vector3 GetLocalPosition(Vector3 localPoint, RectOffset padding);

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="padding"></param>
        void SetPosition(RectOffset padding);

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        void SetPosition(Vector3 localPoint, RectOffset padding);
        #endregion

        #region Mirror Anchored Position
        /// <summary>
        /// Get anchored position of RectTransform apply mirror.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="anchorMin"></param>
        /// <param name="anchorMax"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        Vector2 GetAnchoredPosition(UIMirrorMode mode, out Vector2 anchorMin, out Vector2 anchorMax, out Vector2 pivot);

        /// <summary>
        /// Set position of RectTransform apply mirror.
        /// </summary>
        /// <param name="mode"></param>
        void SetPosition(UIMirrorMode mode);
        #endregion
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITransformExtension.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/27/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UIWidget
{
    /// <summary>
    /// Extension UI transform.
    /// </summary>
    public static class UITransformExtension
    {
        #region Screen To Local Position
        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        public static Vector2 GetLocalPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint)
        {
            var parentRect = rect.parent as RectTransform;
            var localPosition = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, screenPoint, uiCamera, out localPosition);
            return localPosition;
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static Vector2 GetLocalPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset)
        {
            return GetLocalPosition(rect, uiCamera, screenPoint) + offset;
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public static Vector2 GetLocalPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            var pivot = Text.GetTextAnchorPivot(anchor);
            var pivotOffset = rect.pivot - pivot;
            offset += new Vector2(rect.rect.width * pivotOffset.x, rect.rect.height * pivotOffset.y);
            return GetLocalPosition(rect, uiCamera, screenPoint, offset);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint)
        {
            rect.localPosition = GetLocalPosition(rect, uiCamera, screenPoint);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset)
        {
            rect.localPosition = GetLocalPosition(rect, uiCamera, screenPoint, offset);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="uiCamera"></param>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        public static void SetPosition(this RectTransform rect, Camera uiCamera, Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            rect.localPosition = GetLocalPosition(rect, uiCamera, screenPoint, offset, anchor);
        }
        #endregion

        #region Clamp Position In Parent
        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static Vector3 GetLocalPosition(this RectTransform rect, RectOffset padding)
        {
            return GetLocalPosition(rect, rect.localPosition, padding);
        }

        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="localPosition"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static Vector3 GetLocalPosition(this RectTransform rect, Vector3 localPosition, RectOffset padding)
        {
            var parentRect = rect.parent as RectTransform;

            var minX = -parentRect.rect.width * parentRect.pivot.x + rect.rect.width * rect.pivot.x + padding.left;
            var maxX = parentRect.rect.width * (1 - parentRect.pivot.x) - rect.rect.width * (1 - rect.pivot.x) - padding.right;
            localPosition.x = Mathf.Clamp(localPosition.x, minX, maxX);

            var minY = -parentRect.rect.height * parentRect.pivot.y + rect.rect.height * rect.pivot.y + padding.bottom;
            var maxY = parentRect.rect.height * (1 - parentRect.pivot.y) - rect.rect.height * (1 - rect.pivot.y) - padding.top;
            localPosition.y = Mathf.Clamp(localPosition.y, minY, maxY);

            return localPosition;
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="padding"></param>
        public static void SetPosition(this RectTransform rect, RectOffset padding)
        {
            rect.localPosition = GetLocalPosition(rect, padding);
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="localPosition"></param>
        /// <param name="padding"></param>
        public static void SetPosition(this RectTransform rect, Vector3 localPosition, RectOffset padding)
        {
            rect.localPosition = GetLocalPosition(rect, localPosition, padding);
        }
        #endregion

        #region Mirror Anchored Position
        /// <summary>
        /// Get anchored position of RectTransform apply mirror.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="mode"></param>
        /// <param name="anchorMin"></param>
        /// <param name="anchorMax"></param>
        /// <param name="pivot"></param>
        /// <returns></returns>
        public static Vector2 GetAnchoredPosition(this RectTransform rect, UIMirrorMode mode,
            out Vector2 anchorMin, out Vector2 anchorMax, out Vector2 pivot)
        {
            anchorMin = rect.anchorMin;
            anchorMax = rect.anchorMax;
            pivot = rect.pivot;
            var h = 1;
            var v = 1;
            switch (mode)
            {
                case UIMirrorMode.Horizontal:
                    anchorMin.x = 1 - anchorMin.x;
                    anchorMax.x = 1 - anchorMax.x;
                    pivot.x = 1 - pivot.x;
                    h = -1;
                    break;

                case UIMirrorMode.Vertical:
                    anchorMin.y = 1 - anchorMin.y;
                    anchorMax.y = 1 - anchorMax.y;
                    pivot.y = 1 - pivot.y;
                    v = -1;
                    break;

                case UIMirrorMode.Both:
                    anchorMin = Vector2.one - anchorMin;
                    anchorMax = Vector2.one - anchorMax;
                    pivot = Vector2.one - pivot;
                    h = v = -1;
                    break;
            }
            return new Vector2(rect.anchoredPosition.x * h, rect.anchoredPosition.y * v);
        }

        /// <summary>
        /// Set position of RectTransform apply mirror.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="mode"></param>
        public static void SetPosition(this RectTransform rect, UIMirrorMode mode)
        {
            Vector2 anchorMin, anchorMax, pivot;
            var anchoredPos = GetAnchoredPosition(rect, mode, out anchorMin, out anchorMax, out pivot);
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.pivot = pivot;
            rect.anchoredPosition = anchoredPos;
        }
        #endregion
    }

    /// <summary>
    /// Mode of mirror UI.
    /// </summary>
    public enum UIMirrorMode
    {
        /// <summary>
        /// Horizontal mirror.
        /// </summary>
        Horizontal = 0,

        /// <summary>
        /// Vertical mirror.
        /// </summary>
        Vertical = 1,

        /// <summary>
        /// Both horizontal and vertical mirror.
        /// </summary>
        Both = 2
    }
}
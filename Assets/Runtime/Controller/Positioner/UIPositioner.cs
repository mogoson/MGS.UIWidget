/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIPositioner.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI positioner.
    /// </summary>
    public class UIPositioner : UIComponent, IUIPositioner
    {
        /// <summary>
        /// Camera for UI.
        /// </summary>
        public Camera UICamera { protected set; get; }

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            var canvas = transform.root.GetComponentInChildren<Canvas>(true);
            if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                UICamera = canvas.worldCamera;
            }
        }

        #region Screen To Local Position
        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        public Vector2 GetLocalPosition(Vector2 screenPoint)
        {
            return RTransform.GetLocalPosition(UICamera, screenPoint);
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public Vector2 GetLocalPosition(Vector2 screenPoint, Vector2 offset)
        {
            return RTransform.GetLocalPosition(UICamera, screenPoint, offset);
        }

        /// <summary>
        /// Get local position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public Vector2 GetLocalPosition(Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            return RTransform.GetLocalPosition(UICamera, screenPoint, offset, anchor);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        public void SetPosition(Vector2 screenPoint)
        {
            RTransform.SetPosition(UICamera, screenPoint);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        public void SetPosition(Vector2 screenPoint, Vector2 offset)
        {
            RTransform.SetPosition(UICamera, screenPoint, offset);
        }

        /// <summary>
        /// Set position in parent RectTransform.
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="offset"></param>
        /// <param name="anchor"></param>
        public void SetPosition(Vector2 screenPoint, Vector2 offset, TextAnchor anchor)
        {
            RTransform.SetPosition(UICamera, screenPoint, offset, anchor);
        }
        #endregion

        #region Clamp Position In Parent
        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="padding"></param>
        /// <returns></returns>
        public Vector3 GetLocalPosition(RectOffset padding)
        {
            return RTransform.GetLocalPosition(padding);
        }

        /// <summary>
        /// Get local position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public Vector3 GetLocalPosition(Vector3 localPoint, RectOffset padding)
        {
            return RTransform.GetLocalPosition(localPoint, padding);
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="padding"></param>
        public void SetPosition(RectOffset padding)
        {
            RTransform.SetPosition(padding);
        }

        /// <summary>
        /// Set position of RectTransform clamp in paren.
        /// </summary>
        /// <param name="localPoint"></param>
        /// <param name="padding"></param>
        public void SetPosition(Vector3 localPoint, RectOffset padding)
        {
            RTransform.SetPosition(localPoint, padding);
        }
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
        public Vector2 GetAnchoredPosition(UIMirrorMode mode, out Vector2 anchorMin, out Vector2 anchorMax, out Vector2 pivot)
        {
            return RTransform.GetAnchoredPosition(mode, out anchorMin, out anchorMax, out pivot);
        }

        /// <summary>
        /// Set position of RectTransform apply mirror.
        /// </summary>
        /// <param name="mode"></param>
        public void SetPosition(UIMirrorMode mode)
        {
            RTransform.SetPosition(mode);
        }
        #endregion
    }
}
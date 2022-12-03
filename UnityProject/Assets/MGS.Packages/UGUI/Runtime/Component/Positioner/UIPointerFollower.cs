/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIPointerFollower.cs
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
    /// UI pointer follower.
    /// </summary>
    public class UIPointerFollower : UIPositioner
    {
        /// <summary>
        /// 
        /// </summary>
        public TextAnchor anchor;

        /// <summary>
        /// 
        /// </summary>
        public Vector2 offset;

        /// <summary>
        /// 
        /// </summary>
        public RectOffset padding;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Update()
        {
            var localPosition = GetLocalPosition(Input.mousePosition, offset, anchor);
            RectTransform.SetPosition(localPosition, padding);
        }
    }
}
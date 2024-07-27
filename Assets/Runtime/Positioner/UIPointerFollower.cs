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

namespace MGS.UIWidget
{
    /// <summary>
    /// UI pointer follower.
    /// </summary>
    public class UIPointerFollower : UIPositioner
    {
        /// <summary>
        /// 
        /// </summary>
        public RectOffset padding;

        /// <summary>
        /// 
        /// </summary>
        public TextAnchor alignment;

        /// <summary>
        /// 
        /// </summary>
        public Vector2 offset;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Update()
        {
            var localPosition = GetLocalPosition(Input.mousePosition, offset, alignment);
            RTransform.SetPosition(localPosition, padding);
        }
    }
}
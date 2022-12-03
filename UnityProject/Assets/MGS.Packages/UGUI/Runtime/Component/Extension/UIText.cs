/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIText.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/07/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI text.
    /// </summary>
    public class UIText : Text
    {
        /// <summary>
        /// Max width.
        /// </summary>
        public float maxWidth = -1;

        /// <summary>
        /// Max height.
        /// </summary>
        public float maxHeight = -1;

        /// <summary>
        /// Preferred width.
        /// </summary>
        public override float preferredWidth
        {
            get
            {
                if (maxWidth < 0)
                {
                    return base.preferredWidth;
                }
                return Mathf.Min(base.preferredWidth, maxWidth);
            }
        }

        /// <summary>
        /// Preferred height.
        /// </summary>
        public override float preferredHeight
        {
            get
            {
                if (maxHeight < 0)
                {
                    return base.preferredHeight;
                }
                return Mathf.Min(base.preferredHeight, maxHeight);
            }
        }
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIImageCell.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UI.Widget
{
    /// <summary>
    /// Option for image.
    /// </summary>
    [Serializable]
    public struct UIImageOption
    {
        /// <summary>
        /// Display sprite.
        /// </summary>
        public Sprite sprite;
    }

    /// <summary>
    /// UI image cell.
    /// </summary>
    public class UIImageCell : UIRefreshable<UIImageOption>
    {
        /// <summary>
        /// Image component.
        /// </summary>
        public Image image;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            image = GetComponentInChildren<Image>(true);
        }

        /// <summary>
        /// On refresh image.
        /// </summary>
        /// <param name="option">Options to refresh image.</param>
        protected override void OnRefresh(UIImageOption option)
        {
            image.sprite = option.sprite;
        }
    }
}
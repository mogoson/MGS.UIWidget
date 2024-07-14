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

namespace MGS.UGUI
{
    /// <summary>
    /// Options for image.
    /// </summary>
    [Serializable]
    public struct UIImageOptions
    {
        /// <summary>
        /// Display sprite.
        /// </summary>
        public Sprite sprite;
    }

    /// <summary>
    /// UI image cell.
    /// </summary>
    public class UIImageCell : UIRefreshable<UIImageOptions>
    {
        /// <summary>
        /// Image component.
        /// </summary>
        public Image image;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            image = GetComponentInChildren<Image>(true);
        }

        /// <summary>
        /// On refresh image.
        /// </summary>
        /// <param name="options">Options to refresh image.</param>
        protected override void OnRefresh(UIImageOptions options)
        {
            image.sprite = options.sprite;
        }
    }
}
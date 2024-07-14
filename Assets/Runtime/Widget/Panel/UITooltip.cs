/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITooltip.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/14/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine.UI;

namespace MGS.UGUI
{
    [Serializable]
    public struct UITooltipOptions
    {
        public string text;
    }

    /// <summary>
    /// UI Tooltip.
    /// </summary>
    public class UITooltip : UIRefreshable<UITooltipOptions>
    {
        /// <summary>
        /// UI text.
        /// </summary>
        public Text text;

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            text = GetComponentInChildren<Text>(true);
        }

        /// <summary>
        /// On refresh.
        /// </summary>
        /// <param name="data"></param>
        protected override void OnRefresh(UITooltipOptions options)
        {
            text.text = options.text;
        }
    }
}
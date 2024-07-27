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

namespace MGS.UI.Widget
{
    [Serializable]
    public struct UITooltipOption
    {
        public string text;
    }

    /// <summary>
    /// UI Tooltip.
    /// </summary>
    public class UITooltip : UIRefreshable<UITooltipOption>
    {
        /// <summary>
        /// UI text.
        /// </summary>
        public Text text;

        /// <summary>
        /// Reset.
        /// </summary>
        protected virtual void Reset()
        {
            text = GetComponentInChildren<Text>(true);
        }

        /// <summary>
        /// On refresh.
        /// </summary>
        /// <param name="data"></param>
        protected override void OnRefresh(UITooltipOption option)
        {
            text.text = option.text;
        }
    }
}
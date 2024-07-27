/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextCell.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine.UI;

namespace MGS.UI.Widget
{
    /// <summary>
    /// Option for text.
    /// </summary>
    [Serializable]
    public struct UITextOption
    {
        /// <summary>
        /// Display text.
        /// </summary>
        public string text;
    }

    /// <summary>
    /// UI text cell.
    /// </summary>
    public class UITextCell : UIRefreshable<UITextOption>
    {
        /// <summary>
        /// Text component.
        /// </summary>
        public Text text;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            text = GetComponentInChildren<Text>(true);
        }

        /// <summary>
        /// On refresh text.
        /// </summary>
        /// <param name="option">Options to refresh text.</param>
        protected override void OnRefresh(UITextOption option)
        {
            text.text = option.text;
        }
    }
}
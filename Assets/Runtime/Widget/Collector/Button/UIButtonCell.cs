/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIButtonCell.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Options for button.
    /// </summary>
    [Serializable]
    public struct UIButtonOptions
    {
        /// <summary>
        /// Display text.
        /// </summary>
        public string text;
    }

    /// <summary>
    /// UI button cell.
    /// </summary>
    public class UIButtonCell : UIRefreshable<UIButtonOptions>
    {
        /// <summary>
        /// Button component.
        /// </summary>
        public Button button;

        /// <summary>
        /// Text component.
        /// </summary>
        public Text text;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            button = GetComponentInChildren<Button>(true);
            if (button != null)
            {
                text = button.GetComponentInChildren<Text>(true);
            }
        }

        /// <summary>
        /// On refresh image.
        /// </summary>
        /// <param name="options">Options to refresh button.</param>
        protected override void OnRefresh(UIButtonOptions options)
        {
            text.text = options.text;
        }
    }
}
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

namespace MGS.UI.Widget
{
    /// <summary>
    /// Option for button.
    /// </summary>
    [Serializable]
    public struct UIButtonOption
    {
        /// <summary>
        /// Display text.
        /// </summary>
        public string text;
    }

    /// <summary>
    /// UI button cell.
    /// </summary>
    public class UIButtonCell : UIRefreshable<UIButtonOption>
    {
        public event Action<UIButtonCell> OnClickEvent;

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

        protected virtual void Awake()
        {
            button.onClick.AddListener(() => OnClickEvent?.Invoke(this));
        }

        /// <summary>
        /// On refresh image.
        /// </summary>
        /// <param name="option">Options to refresh button.</param>
        protected override void OnRefresh(UIButtonOption option)
        {
            text.text = option.text;
        }
    }
}
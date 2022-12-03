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

namespace MGS.UGUI
{
    /// <summary>
    /// UI Tooltip.
    /// </summary>
    public class UITooltip : UIPanel<string>
    {
        /// <summary>
        /// UI text.
        /// </summary>
        public UIText text;

        /// <summary>
        /// Max width
        /// </summary>
        public float MaxWidth
        {
            set { text.maxWidth = value; }
            get { return text.maxWidth; }
        }

        /// <summary>
        /// Max height.
        /// </summary>
        public float MaxHeight
        {
            set { text.maxHeight = value; }
            get { return text.maxHeight; }
        }

        /// <summary>
        /// Reset.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            text = GetComponentInChildren<UIText>(true);
        }

        /// <summary>
        /// On refresh.
        /// </summary>
        /// <param name="info"></param>
        protected override void OnRefresh(string info)
        {
            text.text = info;
        }
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIButtonCollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/20/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Utility;
using System;

namespace MGS.UGUI
{
    /// <summary>
    /// UI button collector.
    /// </summary>
    public class UIButtonCollector : UICollector<UIButtonCell, UIButtonOptions>
    {
        /// <summary>
        /// On cell click event.
        /// </summary>
        public event Action<UIButtonCell> OnCellClickEvent;

        /// <summary>
        /// Create a new cell from prefab.
        /// </summary>
        /// <returns></returns>
        protected override UIButtonCell CreateCell()
        {
            var cell = base.CreateCell();
            cell.button.onClick.AddListener(() => OnCellClick(cell));
            return cell;
        }

        /// <summary>
        /// On cell click event.
        /// </summary>
        /// <param name="cell">Button cell.</param>
        protected void OnCellClick(UIButtonCell cell)
        {
            ActionUtility.Invoke(OnCellClickEvent, cell);
        }
    }
}
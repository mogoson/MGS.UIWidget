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

using System;

namespace MGS.UIWidget
{
    /// <summary>
    /// UI button collector.
    /// </summary>
    public class UIButtonCollector : UICollector<UIButtonCell, UIButtonOption>
    {
        /// <summary>
        /// On cell click event.
        /// </summary>
        public event Action<UIButtonCell> OnCellClickEvent;

        /// <summary>
        /// Create a new cell from prefab.
        /// </summary>
        /// <returns></returns>
        public override UIButtonCell CreateCell()
        {
            var cell = base.CreateCell();
            cell.OnClickEvent += OnCellClickEvent;
            return cell;
        }
    }
}
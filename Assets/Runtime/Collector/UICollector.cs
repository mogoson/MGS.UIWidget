/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UICollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/19/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.UIWidget
{
    /// <summary>
    /// UI collector.
    /// </summary>
    /// <typeparam name="TCell">Type of cell.</typeparam>
    /// <typeparam name="TOption">Type of option to refresh cell.</typeparam>
    public abstract class UICollector<TCell, TOption> : UIRefreshable<ICollection<TOption>>
        where TCell : UIRefreshable<TOption>
    {
        /// <summary>
        /// Prefab of cell to clone.
        /// </summary>
        public TCell cell;
        protected List<TCell> cells = new List<TCell>();

        /// <summary>
        /// Create a new cell from prefab.
        /// </summary>
        /// <returns></returns>
        public virtual TCell CreateCell()
        {
            var newCell = Instantiate(cell, RTransform);
            newCell.SetActive();

            cells.Add(newCell);
            return newCell;
        }

        /// <summary>
        /// Create a new cell from prefab for option.
        /// </summary>
        public virtual TCell CreateCell(TOption option)
        {
            var cell = CreateCell();
            cell.Refresh(option);
            return cell;
        }

        /// <summary>
        /// Remove the cell from container.
        /// </summary>
        /// <param name="cell"></param>
        public virtual void RemoveCell(TCell cell)
        {
            if (cell != null)
            {
                cells.Remove(cell);
                cell.Destroy();
            }
        }

        /// <summary>
        /// On refresh UI.
        /// </summary>
        /// <param name="options">Options to refresh collector.</param>
        protected override void OnRefresh(ICollection<TOption> options)
        {
            if (options == null || options.Count == 0)
            {
                RequireCells(0);
                return;
            }

            RequireCells(options.Count);

            var index = 0;
            foreach (var option in options)
            {
                cells[index].Refresh(option);
                index++;
            }
        }

        /// <summary>
        /// Require the number of cells.
        /// </summary>
        /// <param name="count"></param>
        protected virtual void RequireCells(int count)
        {
            while (cells.Count > count)
            {
                var cell = cells[cells.Count - 1];
                RemoveCell(cell);
            }
            while (cells.Count < count)
            {
                CreateCell();
            }
        }
    }
}
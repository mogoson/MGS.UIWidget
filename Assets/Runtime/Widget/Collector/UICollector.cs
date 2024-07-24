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

namespace MGS.UGUI
{
    /// <summary>
    /// UI collector.
    /// </summary>
    /// <typeparam name="TCell">Type of cell.</typeparam>
    /// <typeparam name="TData">Type of data to refresh cell.</typeparam>
    public abstract class UICollector<TCell, TData> : UIRefreshable<ICollection<TData>>
        where TCell : UIRefreshable<TData>
    {
        /// <summary>
        /// Prefab of cell to clone.
        /// </summary>
        public TCell cell;

        /// <summary>
        /// Append a cell of data.
        /// </summary>
        public virtual void Append(TData data)
        {
            var cell = CreateCell();
            cell.Refresh(data);
        }

        /// <summary>
        /// On refresh UI.
        /// </summary>
        /// <param name="datas">Datas to refresh collector.</param>
        protected override void OnRefresh(ICollection<TData> datas)
        {
            if (datas == null || datas.Count == 0)
            {
                RequireCells(0);
                return;
            }

            RequireCells(datas.Count);

            //Agreement: the prefab is under the container.
            var index = 1;
            foreach (var data in datas)
            {
                var cell = RTransform.GetChild(index).GetComponent<TCell>();
                cell.gameObject.SetActive(true);
                cell.Refresh(data);
                index++;
            }
        }

        /// <summary>
        /// Require the number of cells.
        /// </summary>
        /// <param name="count"></param>
        protected virtual void RequireCells(int count)
        {
            //Agreement: the prefab is under the container.
            count += 1;
            var childCount = RTransform.childCount;
            while (childCount > count)
            {
                DisposeCell(RTransform.GetChild(childCount - 1).GetComponent<TCell>());
                childCount--;
            }
            while (childCount < count)
            {
                CreateCell();
                childCount++;
            }
        }

        /// <summary>
        /// Create a new cell from prefab.
        /// </summary>
        /// <returns></returns>
        protected virtual TCell CreateCell()
        {
            return Instantiate(cell, RTransform);
        }

        /// <summary>
        /// Dispose the cell from container.
        /// </summary>
        /// <param name="cell">Child index of cell.</param>
        protected virtual void DisposeCell(TCell cell)
        {
            cell.gameObject.SetActive(false);
        }
    }
}
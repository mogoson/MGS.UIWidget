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
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI collector.
    /// </summary>
    /// <typeparam name="TCell">Type of cell.</typeparam>
    /// <typeparam name="TInfo">Type of info to refresh cell.</typeparam>
    public abstract class UICollector<TCell, TInfo> : UIRefreshable<ICollection<TInfo>>
        where TCell : UIRefreshable<TInfo>
    {
        /// <summary>
        /// Container of cells.
        /// </summary>
        public RectTransform container;

        /// <summary>
        /// Prefab of cell to clone.
        /// </summary>
        public TCell cell;

        /// <summary>
        /// On refresh UI.
        /// </summary>
        /// <param name="infos">Infos to refresh collector.</param>
        protected override void OnRefresh(ICollection<TInfo> infos)
        {
            if (infos == null || infos.Count == 0)
            {
                RequireCells(0);
                return;
            }

            RequireCells(infos.Count);

            //Agreement: the prefab is under the container.
            var index = 1;
            foreach (var info in infos)
            {
                var cell = container.GetChild(index).GetComponent<TCell>();
                cell.gameObject.SetActive(true);
                RefreshCell(cell, info);
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
            var childCount = container.childCount;
            while (childCount > count)
            {
                DisposeCell(container.GetChild(childCount - 1).GetComponent<TCell>());
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
            return Instantiate(cell, container);
        }

        /// <summary>
        /// Refresh cell by info.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="info"></param>
        protected virtual void RefreshCell(TCell cell, TInfo info)
        {
            cell.Refresh(info);
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
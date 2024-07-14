/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIRefreshable.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/06/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// Base for UI refreshable.
    /// </summary>
    /// <typeparam name="T">Type of info to refresh UI.</typeparam>
    public abstract class UIRefreshable<T> : UIComponent, IUIRefreshable<T>
    {
        /// <summary>
        /// Data of UI.
        /// </summary>
        public virtual T Data { protected set; get; }

        /// <summary>
        /// Refresh UI.
        /// </summary>
        /// <param name="data">Data to refresh UI.</param>
        public void Refresh(T data)
        {
            Data = data;
            OnRefresh(data);
        }

        /// <summary>
        /// On refresh UI.
        /// </summary>
        /// <param name="data">Data to refresh UI.</param>
        protected abstract void OnRefresh(T data);
    }
}
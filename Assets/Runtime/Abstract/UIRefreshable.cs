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

namespace MGS.UI.Widget
{
    /// <summary>
    /// UI refreshable.
    /// </summary>
    /// <typeparam name="T">Type of option to refresh UI.</typeparam>
    public abstract class UIRefreshable<T> : UIWidget, IUIRefreshable<T>
    {
        /// <summary>
        /// Option of UI.
        /// </summary>
        public virtual T Option { protected set; get; }

        /// <summary>
        /// Refresh UI.
        /// </summary>
        /// <param name="option">Option to refresh UI.</param>
        public void Refresh(T option)
        {
            Option = option;
            OnRefresh(option);
        }

        /// <summary>
        /// On refresh UI.
        /// </summary>
        /// <param name="option">Option to refresh UI.</param>
        protected abstract void OnRefresh(T option);
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIRefreshable.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UI.Widget
{
    /// <summary>
    /// Interface for UI refreshable.
    /// </summary>
    /// <typeparam name="T">Type of option to refresh UI.</typeparam>
    public interface IUIRefreshable<T> : IUIWidget
    {
        /// <summary>
        /// Option of UI.
        /// </summary>
        T Option { get; }

        /// <summary>
        /// Refresh UI.
        /// </summary>
        /// <param name="option">Option to refresh UI.</param>
        void Refresh(T option);
    }
}
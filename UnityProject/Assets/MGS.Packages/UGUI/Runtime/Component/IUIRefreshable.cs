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

namespace MGS.UGUI
{
    /// <summary>
    /// Interface for UI refreshable.
    /// </summary>
    /// <typeparam name="T">Type of info to refresh UI.</typeparam>
    public interface IUIRefreshable<T>
    {
        /// <summary>
        /// Info of UI.
        /// </summary>
        T Info { get; }

        /// <summary>
        /// Refresh UI.
        /// </summary>
        /// <param name="info">Info to refresh UI.</param>
        void Refresh(T info);
    }
}
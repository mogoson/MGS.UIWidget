/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ITooltip.cs
 *  Description  :  Define interface for tooltip.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Mogoson.Tooltip
{
    /// <summary>
    /// Interface for tooltip.
    /// </summary>
    public interface ITooltip
    {
        #region Method
        /// <summary>
        /// Show tooltip.
        /// </summary>
        /// <param name="info">Tooltip info.</param>
        void Show(string info);

        /// <summary>
        /// Close tooltip.
        /// </summary>
        void Close();
        #endregion
    }
}
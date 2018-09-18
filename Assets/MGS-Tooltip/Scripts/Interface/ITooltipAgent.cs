/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ITooltipAgent.cs
 *  Description  :  Define interface for tooltip agent.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/18/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Mogoson.Tooltip
{
    /// <summary>
    /// Interface for tooltip agent.
    /// </summary>
    public interface ITooltipAgent
    {
        #region Method
        /// <summary>
        /// Show tooltip.
        /// </summary>
        /// <param name="tipInfo">Info show in tooltip.</param>
        void ShowTip(string tipInfo);

        /// <summary>
        /// Close tooltip.
        /// </summary>
        void CloseTip();
        #endregion
    }
}
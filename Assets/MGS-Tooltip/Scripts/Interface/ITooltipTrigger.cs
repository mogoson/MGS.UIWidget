/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ITooltipTrigger.cs
 *  Description  :  Define interface for tooltip trigger.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  9/18/2018
 *  Description  :  Initial development version.
 *************************************************************************/

namespace Mogoson.Tooltip
{
    /// <summary>
    /// Interface for tooltip trigger.
    /// </summary>
    public interface ITooltipTrigger
    {
        #region Property
        /// <summary>
        /// Tooltip info.
        /// </summary>
        string TipInfo { set; get; }
        #endregion
    }
}
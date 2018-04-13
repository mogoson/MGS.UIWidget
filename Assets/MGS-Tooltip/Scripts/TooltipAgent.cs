/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipAgent.cs
 *  Description  :  Agent of Tooltip.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.DesignPattern;
using UnityEngine;

namespace Mogoson.Tooltip
{
    /// <summary>
    /// Agent of tooltip.
    /// </summary>
    [AddComponentMenu("Mogoson/Tooltip/TooltipAgent")]
    public sealed class TooltipAgent : SingleMonoBehaviour<TooltipAgent>
    {
        #region Field and Property
        /// <summary>
        /// Tooltip of this agent.
        /// </summary>
        public Tooltip tooltip;
        #endregion

        #region Public Method
        /// <summary>
        /// Show tooltip.
        /// </summary>
        /// <param name="tipInfo">Info show in tooltip.</param>
        public void ShowTip(string tipInfo)
        {
            tooltip.Show(tipInfo);
        }

        /// <summary>
        /// Close tooltip.
        /// </summary>
        public void CloseTip()
        {
            tooltip.Close();
        }
        #endregion
    }
}
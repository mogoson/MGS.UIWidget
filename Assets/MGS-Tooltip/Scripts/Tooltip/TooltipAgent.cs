/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipAgent.cs
 *  Description  :  Agent of TooltipUI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Developer.Singleton;
using UnityEngine;

namespace Developer.Tooltip
{
    [AddComponentMenu("Developer/Tooltip/TooltipAgent")]
    public sealed class TooltipAgent : SingleMonoBehaviour<TooltipAgent>
    {
        #region Field and Property
        /// <summary>
        /// Tooltip of this agent.
        /// </summary>
        public Tooltip tooltip;
        #endregion

        #region Public Method
        public void ShowTip(string tipInfo)
        {
            tooltip.Show(tipInfo);
        }

        public void CloseTip()
        {
            tooltip.Close();
        }
        #endregion
    }
}
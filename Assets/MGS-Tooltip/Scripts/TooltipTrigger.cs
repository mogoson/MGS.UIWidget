/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipTrigger.cs
 *  Description  :  Trigger for Tooltip.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/13/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/8/2018
 *  Description  :  Extend and optimize.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Tooltip
{
    /// <summary>
    /// Trigger for tooltip.
    /// </summary>
    [AddComponentMenu("Mogoson/Tooltip/TooltipTrigger")]
    [RequireComponent(typeof(Collider))]
    public class TooltipTrigger : MonoBehaviour
    {
        #region Field and Property
        /// <summary>
        /// Tooltip info.
        /// </summary>
        [Multiline]
        public string tipInfo = "Tooltip Info";
        #endregion

        #region Protected Method
        protected virtual void OnMouseEnter()
        {
            TooltipAgent.Instance.ShowTip(tipInfo);
        }

        protected virtual void OnMouseExit()
        {
            TooltipAgent.Instance.CloseTip();
        }
        #endregion
    }
}
/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  TooltipTrigger.cs
 *  Description  :  Trigger for TooltipUI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/13/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.Tooltip
{
    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("Developer/Tooltip/TooltipTrigger")]
    public class TooltipTrigger : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Target tooltip UI of trigger.
        /// </summary>
        public TooltipUI UI;

        /// <summary>
        /// Tooltip message.
        /// </summary>
        [Multiline]
        public string text = "Tooltip";
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            UI = FindObjectOfType<TooltipUI>();
        }

        protected virtual void OnMouseEnter()
        {
            UI.Show(text);
        }

        protected virtual void OnMouseExit()
        {
            UI.Close();
        }
        #endregion
    }
}
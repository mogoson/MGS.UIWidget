/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIPointerTrigger.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;

namespace MGS.UGUI
{
    /// <summary>
    /// UI pointer trigger.
    /// </summary>
    public class UIPointerTrigger : UITrigger, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected UIComponent UI;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            UI.ToggleActive(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public virtual void OnPointerExit(PointerEventData eventData)
        {
            UI.ToggleActive(false);
        }
    }
}
/*************************************************************************
 *  Copyright (C) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UISelectListener.cs
 *  Description  :  Event Listener for select.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/14/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine.EventSystems;

namespace MGS.UIWidget
{
    /// <summary>
    ///Event Listener for select.
    /// </summary>
    public sealed class UISelectListener : UIListener,
        ISelectHandler, IUpdateSelectedHandler, IDeselectHandler,
        ISubmitHandler, ICancelHandler
    {
        #region
        /// <summary>
        /// On select event.
        /// </summary>
        public event Action<BaseEventData> OnSelectEvent;

        /// <summary>
        /// On update selected event.
        /// </summary>
        public event Action<BaseEventData> OnUpdateSelectedEvent;

        /// <summary>
        /// On deselect event.
        /// </summary>
        public event Action<BaseEventData> OnDeselectEvent;

        /// <summary>
        /// On submit event.
        /// </summary>
        public event Action<BaseEventData> OnSubmitEvent;

        /// <summary>
        /// On cancel event.
        /// </summary>
        public event Action<BaseEventData> OnCancelEvent;
        #endregion

        #region
        /// <summary>
        /// On select.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnSelect(BaseEventData eventData)
        {
            OnSelectEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On update selected.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnUpdateSelected(BaseEventData eventData)
        {
            OnUpdateSelectedEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On deselect.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDeselect(BaseEventData eventData)
        {
            OnDeselectEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On submit.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnSubmit(BaseEventData eventData)
        {
            OnSubmitEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On cancel.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnCancel(BaseEventData eventData)
        {
            OnCancelEvent?.Invoke(eventData);
        }
        #endregion
    }
}
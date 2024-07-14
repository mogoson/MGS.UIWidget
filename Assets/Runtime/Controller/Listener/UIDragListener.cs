/*************************************************************************
 *  Copyright (C) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIDragListener.cs
 *  Description  :  Event Listener for drag.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  7/14/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine.EventSystems;

namespace MGS.UGUI
{
    /// <summary>
    ///Event Listener for drag.
    /// </summary>
    public sealed class UIDragListener : UIListener,
        IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler,
        IDropHandler, IScrollHandler, IMoveHandler
    {
        #region
        /// <summary>
        /// On initialize potential drag event.
        /// </summary>
        public event Action<PointerEventData> OnInitializePotentialDragEvent;

        /// <summary>
        /// On begin drag event.
        /// </summary>
        public event Action<PointerEventData> OnBeginDragEvent;

        /// <summary>
        /// On drag event.
        /// </summary>
        public event Action<PointerEventData> OnDragEvent;

        /// <summary>
        /// On end drag event.
        /// </summary>
        public event Action<PointerEventData> OnEndDragEvent;

        /// <summary>
        /// On drop event.
        /// </summary>
        public event Action<PointerEventData> OnDropEvent;

        /// <summary>
        /// On scroll event.
        /// </summary>
        public event Action<PointerEventData> OnScrollEvent;

        /// <summary>
        /// On move event.
        /// </summary>
        public event Action<AxisEventData> OnMoveEvent;
        #endregion

        #region
        /// <summary>
        /// On initialize potential drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            OnInitializePotentialDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On begin drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDrag(PointerEventData eventData)
        {
            OnDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On end drag.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndDragEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On drop.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnDrop(PointerEventData eventData)
        {
            OnDropEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On scroll.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnScroll(PointerEventData eventData)
        {
            OnScrollEvent?.Invoke(eventData);
        }

        /// <summary>
        /// On move.
        /// </summary>
        /// <param name="eventData">Pointer event data.</param>
        public void OnMove(AxisEventData eventData)
        {
            OnMoveEvent?.Invoke(eventData);
        }
        #endregion
    }
}
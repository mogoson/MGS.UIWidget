/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIRespondable.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/4
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.UI.Widget
{
    public abstract class UIRespondable<T> : UIRefreshable<T>, IUIRespondable<T>
    {
        public event Action<T> OnDirtyEvent;

        protected void OnDirty()
        {
            OnDirtyEvent?.Invoke(Option);
        }
    }
}
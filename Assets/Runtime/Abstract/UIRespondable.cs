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

namespace MGS.UGUI
{
    public abstract class UIRespondable<T, K> : UIRefreshable<T>, IUIRespondable<T, K>
    {
        public event Action<K> OnChangedEvent;

        protected void OnChanged(K data)
        {
            OnChangedEvent?.Invoke(data);
        }
    }
}
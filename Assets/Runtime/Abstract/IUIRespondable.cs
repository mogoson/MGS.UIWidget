/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIRespondable.cs
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
    public interface IUIRespondable<T> : IUIRefreshable<T>
    {
        event Action<T> OnDirtyEvent;
    }
}
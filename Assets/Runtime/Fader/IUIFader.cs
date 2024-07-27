/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIFader.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/5
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.UIWidget
{
    public interface IUIFader : IUIWidget
    {
        /// <summary>
        /// Start fade.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="faded"></param>
        void StartFade(float duration, Action faded = null);

        /// <summary>
        /// Stop fade.
        /// </summary>
        void StopFade();
    }
}
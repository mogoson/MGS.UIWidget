/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IUIWidget.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/5
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UIWidget
{
    public interface IUIWidget
    {
        /// <summary>
        /// Enabled Behaviours are Updated, disabled Behaviours are not.
        /// </summary>
        bool enabled { set; get; }

        /// <summary>
        /// Set gameObject active.
        /// </summary>
        /// <param name="isActive"></param>
        void SetActive(bool isActive);

        /// <summary>
        /// 
        /// </summary>
        void Destroy();
    }
}
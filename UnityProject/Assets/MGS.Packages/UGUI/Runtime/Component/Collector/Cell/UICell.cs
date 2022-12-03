/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UICell.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// UI cell.
    /// </summary>
    /// <typeparam name="T">Type of info to refresh cell.</typeparam>
    public abstract class UICell<T> : UIRefreshable<T> { }
}
/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Tooltip.cs
 *  Description  :  Define tooltip.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/8/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Tooltip
{
    /// <summary>
    /// Tooltip component.
    /// </summary>
    public abstract class Tooltip : MonoBehaviour
    {
        #region Public Method
        /// <summary>
        /// Show tooltip.
        /// </summary>
        /// <param name="info">Tooltip info.</param>
        public abstract void Show(string info);

        /// <summary>
        /// Close tooltip.
        /// </summary>
        public abstract void Close();
        #endregion
    }
}
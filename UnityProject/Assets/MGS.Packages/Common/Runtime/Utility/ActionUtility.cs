/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ActionUtility.cs
 *  Description  :  Utility for Action.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  11/24/2022
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.Common.Utility
{
    /// <summary>
    /// Utility for Action.
    /// </summary>
    public sealed class ActionUtility
    {
        /// <summary>
        /// Invoke action.
        /// </summary>
        /// <param name="action"></param>
        public static void Invoke(Action action)
        {
            if (action != null)
            {
                action.Invoke();
            }
        }

        /// <summary>
        /// Invoke action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg"></param>
        public static void Invoke<T>(Action<T> action, T arg)
        {
            if (action != null)
            {
                action.Invoke(arg);
            }
        }

        /// <summary>
        /// Invoke action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="action"></param>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        public static void Invoke<T, K>(Action<T, K> action, T arg0, K arg1)
        {
            if (action != null)
            {
                action.Invoke(arg0, arg1);
            }
        }
    }
}
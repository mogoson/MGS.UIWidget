/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UICoroutine.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Utility;
using System;
using System.Collections;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// Coroutine Factory.
    /// </summary>
    public sealed class UICoroutine
    {
        /// <summary>
        /// Timer delay to do something.
        /// </summary>
        /// <param name="delay">Delay seconds.</param>
        /// <param name="elapsed">Event on elapsed.</param>
        /// <returns></returns>
        public static IEnumerator Timer(float delay, Action elapsed)
        {
            yield return new WaitForSeconds(delay);
            ActionUtility.Invoke(elapsed);
        }

        /// <summary>
        /// Timer tick to do something.
        /// </summary>
        /// <param name="duration">Duration seconds.</param>
        /// <param name="tick"></param>
        /// <param name="elapsed"></param>
        /// <returns></returns>
        public static IEnumerator Timer(float duration, Action<float> tick, Action elapsed = null)
        {
            var timer = 0f;
            while (timer <= duration)
            {
                ActionUtility.Invoke(tick, timer / duration);
                yield return null;
                timer += Time.deltaTime;
            }
            ActionUtility.Invoke(tick, 1.0f);
            ActionUtility.Invoke(elapsed);
        }

        /// <summary>
        /// Timer delay to tick to do something.
        /// </summary>
        /// <param name="delay">Delay seconds.</param>
        /// <param name="duration">Duration seconds.</param>
        /// <param name="timing"></param>
        /// <param name="tick"></param>
        /// <param name="elapsed"></param>
        /// <returns></returns>
        public static IEnumerator Timer(float delay, float duration, Action timing, Action<float> tick, Action elapsed = null)
        {
            yield return new WaitForSeconds(delay);
            ActionUtility.Invoke(timing);
            yield return Timer(duration, tick, elapsed);
        }
    }
}
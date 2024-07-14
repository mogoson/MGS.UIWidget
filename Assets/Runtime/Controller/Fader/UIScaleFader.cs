/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIScaleFader.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI scale fader.
    /// </summary>
    public class UIScaleFader : UIFader
    {
        /// <summary>
        /// 
        /// </summary>
        public Vector3 from = Vector3.zero;

        /// <summary>
        /// 
        /// </summary>
        public Vector3 to = Vector3.one;

        /// <summary>
        /// Start fade.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="faded"></param>
        public virtual void StartFade(Vector3 from, Vector3 to, float duration, Action faded = null)
        {
            this.from = from;
            this.to = to;
            StartFade(duration, faded);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        protected override void OnFade(float progress)
        {
            transform.localScale = Evaluate(from, to, progress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected virtual Vector3 Evaluate(Vector3 from, Vector3 to, float t)
        {
            return Vector3.Lerp(from, to, t);
        }
    }
}
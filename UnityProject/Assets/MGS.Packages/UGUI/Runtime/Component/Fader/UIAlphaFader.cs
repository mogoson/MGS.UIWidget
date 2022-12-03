/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIAlphaFader.cs
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
    /// UI alpha fader.
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class UIAlphaFader : UIFader
    {
        /// <summary>
        /// 
        /// </summary>
        protected CanvasGroup canvasGroup;

        /// <summary>
        /// 
        /// </summary>
        protected float from;

        /// <summary>
        /// 
        /// </summary>
        protected float to;

        /// <summary>
        /// 
        /// </summary>
        public float Alpha
        {
            set { canvasGroup.alpha = value; }
            get { return canvasGroup.alpha; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="faded"></param>
        public virtual void StartFade(float delay, float from, float to, float duration, Action faded = null)
        {
            this.from = from;
            this.to = to;
            StartFade(delay, duration, faded);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        protected override void OnFade(float progress)
        {
            canvasGroup.alpha = Evaluate(from, to, progress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected virtual float Evaluate(float from, float to, float t)
        {
            return Mathf.Lerp(from, to, t);
        }
    }
}
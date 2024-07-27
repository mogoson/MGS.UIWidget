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

namespace MGS.UI.Widget
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
        public float from = 0;

        /// <summary>
        /// 
        /// </summary>
        public float to = 1;

        /// <summary>
        /// 
        /// </summary>
        public float Alpha
        {
            set { canvasGroup.alpha = value; }
            get { return canvasGroup.alpha; }
        }
        protected CanvasGroup canvasGroup;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="faded"></param>
        public virtual void StartFade(float from, float to, float duration, Action faded = null)
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
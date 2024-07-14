/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFader.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI fader.
    /// </summary>
    public abstract class UIFader : UIComponent, IUIFader
    {
        /// <summary>
        /// 
        /// </summary>
        protected IEnumerator fader;

        /// <summary>
        /// Start fade.
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="faded"></param>
        public virtual void StartFade(float duration, Action faded = null)
        {
            if (fader == null)
            {
                OnBeginFade();
                fader = Timer(duration,
                (time) =>
                {
                    var progress = time / duration;
                    OnFade(progress);
                },
                () =>
                {
                    OnEndFade();
                    faded?.Invoke();
                });
                StartCoroutine(fader);
            }
        }

        /// <summary>
        /// Stop fade.
        /// </summary>
        public virtual void StopFade()
        {
            if (fader == null)
            {
                return;
            }

            StopCoroutine(fader);
            fader = null;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnBeginFade() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="progress"></param>
        protected abstract void OnFade(float progress);

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnEndFade()
        {
            fader = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seconds"></param>
        /// <param name="tick"></param>
        /// <param name="arrived"></param>
        /// <returns></returns>
        protected IEnumerator Timer(float seconds, Action<float> tick, Action arrived)
        {
            var timer = 0f;
            while (timer < seconds)
            {
                yield return null;
                timer += Time.deltaTime;
                tick?.Invoke(timer);
            }
            arrived?.Invoke();
        }
    }
}
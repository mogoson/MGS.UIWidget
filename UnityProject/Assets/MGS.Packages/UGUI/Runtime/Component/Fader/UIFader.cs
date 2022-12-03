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

using MGS.Common.Utility;
using System;
using System.Collections;

namespace MGS.UGUI
{
    /// <summary>
    /// UI fader.
    /// </summary>
    public abstract class UIFader : UIComponent
    {
        /// <summary>
        /// 
        /// </summary>
        protected IEnumerator fader;

        /// <summary>
        /// Start fade.
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="duration"></param>
        /// <param name="faded"></param>
        protected virtual void StartFade(float delay, float duration, Action faded = null)
        {
            if (fader == null)
            {
                fader = UICoroutine.Timer(delay, duration, OnBeginFade, OnFade, () =>
                {
                    OnEndFade();
                    ActionUtility.Invoke(faded);
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
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIColorFader.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Color Fader.
    /// </summary>
    [RequireComponent(typeof(Graphic))]
    public class UIColorFader : UIFader
    {
        /// <summary>
        /// 
        /// </summary>
        public Color from = Color.white;

        /// <summary>
        /// 
        /// </summary>
        public Color to = Color.black;

        /// <summary>
        /// 
        /// </summary>
        public Color Color
        {
            set { graphic.color = value; }
            get { return graphic.color; }
        }
        protected Graphic graphic;

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            graphic = GetComponent<Graphic>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="duration"></param>
        /// <param name="faded"></param>
        public virtual void StartFade(Color from, Color to, float duration, Action faded = null)
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
            graphic.color = Evaluate(from, to, progress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        protected virtual Color Evaluate(Color from, Color to, float t)
        {
            return Color.Lerp(from, to, t);
        }
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextClipper.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/9/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UI.Widget
{
    /// <summary>
    /// UI text clipper.
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class UITextClipper : UIWidget
    {
        /// <summary>
        /// Clipping stamp.
        /// </summary>
        public string stamp = "...";

        /// <summary>
        /// Origin text.
        /// </summary>
        public string Text
        {
            set { originText = text.text = value; }
            get { return originText; }
        }
        protected string originText;
        protected Text text;

        /// <summary>
        /// Awake component.
        /// </summary>
        protected virtual void Awake()
        {
            text = GetComponent<Text>();
            text.RegisterDirtyVerticesCallback(OnDirty);

            originText = text.text;
            OnDirty();
        }

        /// <summary>
        /// On Dirty.
        /// </summary>
        protected virtual void OnDirty()
        {
            text.SetClippingText(originText, stamp);
        }
    }
}
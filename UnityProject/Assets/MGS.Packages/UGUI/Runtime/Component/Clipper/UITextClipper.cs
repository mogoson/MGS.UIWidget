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

using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI text clipper.
    /// </summary>
    public class UITextClipper : UIComponent
    {
        /// <summary>
        /// Text component.
        /// </summary>
        public Text text;

        /// <summary>
        /// Clipping stamp.
        /// </summary>
        public string stamp = "...";

        /// <summary>
        /// String value of this text.
        /// </summary>
        public string Text
        {
            set { text.text = originText = value; }
            get { return originText; }
        }

        /// <summary>
        /// Origin string value of this text.
        /// </summary>
        protected string originText;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();
            text = GetComponentInChildren<Text>();
        }

        /// <summary>
        /// Awake component.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            originText = text.text;
            text.RegisterDirtyVerticesCallback(OnClipText);
        }

        /// <summary>
        /// On clip text.
        /// </summary>
        protected virtual void OnClipText()
        {
            text.SetClippingText(originText, stamp);
        }
    }
}
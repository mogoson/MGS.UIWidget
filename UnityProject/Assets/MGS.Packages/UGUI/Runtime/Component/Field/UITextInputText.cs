/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextInputText.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Utility;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Text-Input-Text.
    /// </summary>
    public class UITextInputText : UIComponent
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Text tittle;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected InputField input;

        /// <summary>
        /// 
        /// </summary>
        protected Text caption;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Text stamp;

        /// <summary>
        /// 
        /// </summary>
        public string Tittle
        {
            set { tittle.text = value; }
            get { return tittle.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { input.text = value; }
            get { return input.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            set { caption.text = value; }
            get { return caption.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public InputField.ContentType ContentType
        {
            set { input.contentType = value; }
            get { return input.contentType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CharacterLimit
        {
            set { input.characterLimit = value; }
            get { return input.characterLimit; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Stamp
        {
            set { stamp.text = value; }
            get { return stamp.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Action<string> OnValueChangedEvent;

        /// <summary>
        /// 
        /// </summary>
        public Action<string> OnEndEditEvent;

        /// <summary>
        /// 
        /// </summary>
        protected Func<string, string> beforeValueChange;

        /// <summary>
        /// 
        /// </summary>
        protected Func<string, string> beforeEndEdit;

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            caption = input.GetComponentInChildren<Text>();
            input.onValueChanged.AddListener(Input_OnValueChanged);
            input.onEndEdit.AddListener(Input_OnEndEdit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void InitForInteger(int value, int min, int max)
        {
            ContentType = InputField.ContentType.IntegerNumber;
            beforeEndEdit = (text) =>
            {
                var number = 0;
                if (int.TryParse(text, out number))
                {
                    if (number < min || number > max)
                    {
                        number = Mathf.Clamp(number, min, max);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        number = value;
                    }
                    else if (text.StartsWith("-"))
                    {
                        number = min;
                    }
                    else
                    {
                        number = max;
                    }
                }

                text = number.ToString();
                Content = text;
                return text;
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tittle"></param>
        /// <param name="content"></param>
        /// <param name="caption"></param>
        /// <param name="stamp"></param>
        public void Refresh(string tittle = null, string content = null, string caption = null, string stamp = null)
        {
            Tittle = tittle;
            Content = content;
            Caption = caption;
            Stamp = stamp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void Input_OnValueChanged(string value)
        {
            if (beforeValueChange != null)
            {
                value = beforeValueChange.Invoke(value);
            }
            ActionUtility.Invoke(OnValueChangedEvent, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void Input_OnEndEdit(string value)
        {
            if (beforeEndEdit != null)
            {
                value = beforeEndEdit.Invoke(value);
            }
            ActionUtility.Invoke(OnEndEditEvent, value);
        }
    }
}
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
    public class UITextInputText : UIField<UITextInputTextOptions>
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
        public event Action<string> OnValueChangedEvent;

        /// <summary>
        /// 
        /// </summary>
        public event Action<string> OnEndEditEvent;

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
        protected bool ignoreChange = false;

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
        /// <param name="default"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void InitForIntegerNumber(int @default, int min, int max)
        {
            ContentType = InputField.ContentType.IntegerNumber;
            beforeEndEdit = (text) =>
            {
                var result = 0;
                if (int.TryParse(text, out result))
                {
                    if (result < min || result > max)
                    {
                        result = Mathf.Clamp(result, min, max);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        result = @default;
                    }
                    else if (text.StartsWith("-"))
                    {
                        result = min;
                    }
                    else
                    {
                        result = max;
                    }
                }

                text = result.ToString();
                SetContent(text, true);
                return text;
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="default"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void InitForDecimalNumber(float @default, float min, float max)
        {
            ContentType = InputField.ContentType.DecimalNumber;
            beforeEndEdit = (text) =>
            {
                var result = 0f;
                if (float.TryParse(text, out result))
                {
                    if (result < min || result > max)
                    {
                        result = Mathf.Clamp(result, min, max);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        result = @default;
                    }
                    else if (text.StartsWith("-"))
                    {
                        result = min;
                    }
                    else
                    {
                        result = max;
                    }
                }

                text = result.ToString();
                SetContent(text, true);
                return text;
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected override void OnRefresh(UITextInputTextOptions info)
        {
            Tittle = info.tittle;
            SetContent(info.content, true);
            Caption = info.caption;
            Stamp = info.stamp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="ignoreChange"></param>
        protected void SetContent(string content, bool ignoreChange)
        {
            this.ignoreChange = ignoreChange;
            Content = content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void Input_OnValueChanged(string value)
        {
            if (ignoreChange)
            {
                ignoreChange = false;
                return;
            }

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

    /// <summary>
    /// Options for UITextInputText.
    /// </summary>
    [Serializable]
    public struct UITextInputTextOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string tittle;
        /// <summary>
        /// 
        /// </summary>
        public string content;
        /// <summary>
        /// 
        /// </summary>
        public string caption;
        /// <summary>
        /// 
        /// </summary>
        public string stamp;
    }
}
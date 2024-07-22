/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIImageTextField.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    [Serializable]
    public struct UIImageTextFieldOptions
    {
        public Sprite sprite;
        public string text;
    }

    public class UIImageTextField : UIRefreshable<UIImageTextFieldOptions>
    {
        public Image image;
        public Text text;

        protected virtual void Reset()
        {
            image = GetComponentInChildren<Image>(true);
            text = GetComponentInChildren<Text>(true);
        }

        protected override void OnRefresh(UIImageTextFieldOptions options)
        {
            image.sprite = options.sprite;
            text.text = options.text;
        }
    }
}
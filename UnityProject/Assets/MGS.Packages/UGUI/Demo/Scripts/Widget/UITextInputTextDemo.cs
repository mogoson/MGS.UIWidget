/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextInputTextDemo.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/8/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI.Demo
{
    public class UITextInputTextDemo : MonoBehaviour
    {
        public UITextInputText inputStandard;
        public UITextInputText inputInteger;
        public UITextInputText inputDecimal;

        private void Awake()
        {
            inputStandard.OnEndEditEvent += InputText_OnEndEditEvent;

            inputInteger.InitForIntegerNumber(30, 0, 100);
            inputInteger.OnEndEditEvent += InputText_OnEndEditEvent;

            inputDecimal.InitForDecimalNumber(60, 50, 65);
            inputDecimal.OnEndEditEvent += InputText_OnEndEditEvent;
        }

        private void Start()
        {
            var optionsS = new UITextInputTextOptions()
            {
                tittle = "Name:",
                content = "Mogoson",
                caption = "Enter text..."
            };
            inputStandard.Refresh(optionsS);

            var optionsI = new UITextInputTextOptions()
            {
                tittle = "Age:",
                content = "30",
                caption = "Enter number...",
                stamp = "Years"
            };
            inputInteger.Refresh(optionsI);

            var optionsD = new UITextInputTextOptions()
            {
                tittle = "Weight:",
                content = "60",
                caption = "Enter number...",
                stamp = "KG"
            };
            inputDecimal.Refresh(optionsD);
        }

        private void InputText_OnEndEditEvent(string value)
        {
            Debug.LogFormat("InputText_OnEndEditEvent value is {0}", value);
        }
    }
}
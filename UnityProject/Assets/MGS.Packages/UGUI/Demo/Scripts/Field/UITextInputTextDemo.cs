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
        public UITextInputText inputText;

        private void Awake()
        {
            inputText.InitForInteger(56, 0, 1000);
            inputText.OnEndEditEvent += InputText_OnEndEditEvent;
        }

        private void Start()
        {
            inputText.Refresh("Weight:", "56", "Enter number...", "KG");
        }

        private void InputText_OnEndEditEvent(string value)
        {
            Debug.LogFormat("InputText_OnEndEditEvent value is {0}", value);
        }
    }
}
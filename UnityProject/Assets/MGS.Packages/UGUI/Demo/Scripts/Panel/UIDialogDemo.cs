/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIDialogDemo.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/13/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI.Demo
{
    public class UIDialogDemo : MonoBehaviour
    {
        public UIDialog dialogBox;

        public Button btnConfirm;
        public Button btnSelectYN;
        public Button btnSelectYNC;

        private void Awake()
        {
            Action<UIDialogResult> call = (result) =>
            {
                Debug.LogFormat("Your select result is {0}", result);
            };

            btnConfirm.onClick.AddListener(() =>
            {
                var option = new UIDialogOptions
                {
                    tittle = "Confirm",
                    minimizeButton = true,
                    closeButton = true,
                    content = "This is demo for dialog box test.",
                    yesButton = "OK",
                    callback = call
                };
                dialogBox.Refresh(option);
            });

            btnSelectYN.onClick.AddListener(() =>
            {
                var option = new UIDialogOptions
                {
                    tittle = "Select Y/N",
                    minimizeButton = true,
                    closeButton = true,
                    content = "This is demo for dialog box test, you can select Yes or No.",
                    yesButton = "Yes",
                    noButton = "No",
                    callback = call
                };
                dialogBox.Refresh(option);
            });

            btnSelectYNC.onClick.AddListener(() =>
            {
                var option = new UIDialogOptions
                {
                    tittle = "Select Y/N/C",
                    minimizeButton = true,
                    closeButton = true,
                    content = "This is demo for dialog box test, you can select Yes or No, or Cancel.",
                    yesButton = "Yes",
                    noButton = "No",
                    cancelButton = "Cancel",
                    callback = call
                };
                dialogBox.Refresh(option);
            });
        }
    }
}
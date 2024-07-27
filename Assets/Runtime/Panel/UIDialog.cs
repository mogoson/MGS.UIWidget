/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIDialog.cs
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

namespace MGS.UI.Widget
{
    /// <summary>
    /// 
    /// </summary>
    public enum UIDialogResult
    {
        /// <summary>
        /// 
        /// </summary>
        Minimize = -2,
        /// <summary>
        /// 
        /// </summary>
        Close = -1,
        /// <summary>
        /// 
        /// </summary>
        Yes = 0,
        /// <summary>
        /// 
        /// </summary>
        No = 1,
        /// <summary>
        /// 
        /// </summary>
        Cancel = 2
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public struct UIDialogOption
    {
        /// <summary>
        /// 
        /// </summary>
        public string tittle;
        /// <summary>
        /// 
        /// </summary>
        public bool minimizeButton;
        /// <summary>
        /// 
        /// </summary>
        public bool closeButton;

        /// <summary>
        /// 
        /// </summary>
        public Sprite icon;
        /// <summary>
        /// 
        /// </summary>
        public string content;

        /// <summary>
        /// 
        /// </summary>
        public string yesButton;
        /// <summary>
        /// 
        /// </summary>
        public string noButton;
        /// <summary>
        /// 
        /// </summary>
        public string cancelButton;

        /// <summary>
        /// 
        /// </summary>
        public Action<UIDialogResult> callback;
    }

    /// <summary>
    /// UI dialog.
    /// </summary>
    public class UIDialog : UIRefreshable<UIDialogOption>
    {
        /// <summary>
        /// 
        /// </summary>
        [Header("Tittle Bar")]
        public Text txtTittle;
        /// <summary>
        /// 
        /// </summary>
        public Button btnMinimize;
        /// <summary>
        /// 
        /// </summary>
        public Button btnClose;
        /// <summary>
        /// 
        /// </summary>
        [Header("Content Area")]
        public Image imgIcon;
        /// <summary>
        /// 
        /// </summary>
        public Text txtContent;
        /// <summary>
        /// 
        /// </summary>
        [Header("Tool Bar")]
        public Button btnYes;
        /// <summary>
        /// 
        /// </summary>
        public Text txtYes;
        /// <summary>
        /// 
        /// </summary>
        [Space(3)]
        public Button btnNo;
        /// <summary>
        /// 
        /// </summary>
        public Text txtNo;
        /// <summary>
        ///
        /// </summary>
        [Space(3)]
        public Button btnCancel;
        /// <summary>
        /// 
        /// </summary>
        public Text txtCancel;

        /// <summary>
        /// 
        /// </summary>
        protected Action<UIDialogResult> callback;

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            BindingEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void BindingEvents()
        {
            btnMinimize.onClick.AddListener(() =>
            {
                callback?.Invoke(UIDialogResult.Minimize);
                Minimize();
            });
            btnClose.onClick.AddListener(() =>
            {
                callback?.Invoke(UIDialogResult.Close);
                SetActive(false);
            });

            btnYes.onClick.AddListener(() =>
            {
                callback?.Invoke(UIDialogResult.Yes);
                SetActive(false);
            });
            btnNo.onClick.AddListener(() =>
            {
                callback?.Invoke(UIDialogResult.No);
                SetActive(false);
            });
            btnCancel.onClick.AddListener(() =>
            {
                callback?.Invoke(UIDialogResult.Cancel);
                SetActive(false);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Minimize()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="option"></param>
        protected override void OnRefresh(UIDialogOption option)
        {
            callback = option.callback;

            txtTittle.text = option.tittle;
            btnMinimize.gameObject.SetActive(option.minimizeButton);
            btnClose.gameObject.SetActive(option.closeButton);

            if (option.icon == null) { imgIcon.gameObject.SetActive(false); }
            else
            {
                imgIcon.sprite = option.icon;
                imgIcon.gameObject.SetActive(true);
            }
            txtContent.text = option.content;

            if (string.IsNullOrEmpty(option.yesButton)) { btnYes.gameObject.SetActive(false); }
            else
            {
                txtYes.text = option.yesButton;
                btnYes.gameObject.SetActive(true);
            }
            if (string.IsNullOrEmpty(option.noButton)) { btnNo.gameObject.SetActive(false); }
            else
            {
                txtNo.text = option.noButton;
                btnNo.gameObject.SetActive(true);
            }
            if (string.IsNullOrEmpty(option.cancelButton)) { btnCancel.gameObject.SetActive(false); }
            else
            {
                txtCancel.text = option.cancelButton;
                btnCancel.gameObject.SetActive(true);
            }
        }
    }
}
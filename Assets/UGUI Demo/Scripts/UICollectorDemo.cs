/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UICustomItem.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/23/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI.Demo
{
    public class UICollectorDemo : MonoBehaviour
    {
        public UITextCollector textCollector;
        public List<UITextOptions> txtOptions;

        [Space(5)]
        public UIImageCollector imageCollector;
        public List<UIImageOptions> imgOptions;

        [Space(5)]
        public UIButtonCollector buttonCollector;
        public List<UIButtonOptions> btnOptions;

        [Space(5)]
        public Button btnAppend;
        public Button btnRemove;

        private void Awake()
        {
            buttonCollector.OnCellClickEvent += ButtonCollector_OnCellClickEvent;
            btnAppend.onClick.AddListener(BtnAppend_OnClick);
            btnRemove.onClick.AddListener(BtnRemove_OnClick);
        }

        private void ButtonCollector_OnCellClickEvent(UIButtonCell cell)
        {
            Debug.LogFormat("ButtonCollector_OnCellClickEvent text: {0}", cell.Data.text);
        }

        private void BtnAppend_OnClick()
        {
            txtOptions.Add(new UITextOptions { text = txtOptions[0].text });
            imgOptions.Add(new UIImageOptions { sprite = imgOptions[0].sprite });
            btnOptions.Add(new UIButtonOptions { text = btnOptions[0].text });
            RefreshCollectors();
        }

        private void BtnRemove_OnClick()
        {
            if (txtOptions.Count > 1)
            {
                txtOptions.RemoveAt(txtOptions.Count - 1);
            }
            if (imgOptions.Count > 1)
            {
                imgOptions.RemoveAt(imgOptions.Count - 1);
            }
            if (btnOptions.Count > 1)
            {
                btnOptions.RemoveAt(btnOptions.Count - 1);
            }
            RefreshCollectors();
        }

        private void Start()
        {
            RefreshCollectors();
        }

        private void RefreshCollectors()
        {
            textCollector.Refresh(txtOptions);
            imageCollector.Refresh(imgOptions);
            buttonCollector.Refresh(btnOptions);
        }
    }
}
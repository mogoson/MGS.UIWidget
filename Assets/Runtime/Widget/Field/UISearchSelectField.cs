/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UISearchSelectField.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Input Search Field.
    /// </summary>
    public class UISearchSelectField : UIComponent
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected InputField iptKeyword;
        /// <summary>
        /// 
        /// </summary>
        protected Text txtCaption;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Button btnSearch;
        /// <summary>
        /// 
        /// </summary>
        protected Text txtSearch;
        /// <summary>
        /// 
        /// </summary>
        protected Image imgSearch;

        [SerializeField]
        protected ScrollRect scrSearch;
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected UIButtonCollector collSearch;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected bool emptyMatchAll;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected bool emptyKeepSelect;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Dropdown.OptionData optSearch;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Dropdown.OptionData optClear;

        /// <summary>
        /// On cellclick event (value of the select item).
        /// </summary>
        public event Action<string> OnCellClickEvent;

        /// <summary>
        /// 
        /// </summary>
        protected bool ignoreChange;
        /// <summary>
        /// 
        /// </summary>
        protected bool ignoreSelect;
        /// <summary>
        /// 
        /// </summary>
        protected string lastSelect;

        /// <summary>
        /// 
        /// </summary>
        public string Keyword
        {
            set { iptKeyword.text = value; }
            get { return iptKeyword.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            set { txtCaption.text = value; }
            get { return txtCaption.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected List<string> items = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        protected virtual void Awake()
        {
            txtCaption = iptKeyword.GetComponentInChildren<Text>();
            txtSearch = btnSearch.GetComponentInChildren<Text>();
            imgSearch = btnSearch.GetComponent<Image>();
            scrSearch.RequireCanvasRaycasterGroup();

            var listener = iptKeyword.RequireSelectListener();
            listener.OnSelectEvent += IptKeyword_OnSelectEvent; ;
            listener.OnDeselectEvent += IptKeyword_OnDeselectEvent;
            iptKeyword.onValueChanged.AddListener(IptKeyword_OnValueChanged);
            btnSearch.onClick.AddListener(BtnSearch_OnClick);
            collSearch.OnCellClickEvent += CollSearch_OnCellClickEvent;
        }

        /// <summary>
        /// Refresh data items and select.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="select"></param>
        /// <param name="caption"></param>
        public void Refresh(string[] items, int select = -1, string caption = null)
        {
            this.items.Clear();
            var keyword = string.Empty;
            if (items != null)
            {
                this.items.AddRange(items);
                if (select >= 0 && select < items.Length)
                {
                    keyword = items[select];
                }
            }
            lastSelect = keyword;
            IptKeyword_Set(keyword);
            Caption = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="ignoreChange"></param>
        protected void IptKeyword_Set(string content, bool ignoreChange = true)
        {
            this.ignoreChange = ignoreChange;
            Keyword = content; //Ipt_Keyword_OnValueChanged invoke now if Keyword!=content;
            this.ignoreChange = false;  //Require clear tag, Ipt_Keyword_OnValueChanged do not invoke if Keyword==content;
            SetSearchBtnOption(content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ignoreSelect"></param>
        protected void IptKeyword_Select(bool ignoreSelect = true)
        {
            this.ignoreSelect = ignoreSelect;
            iptKeyword.OnSelect(null);
            //this.ignoreSelect = false; //Ipt_Keyword_OnSelectEvent invoke after this method.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void IptKeyword_OnSelectEvent(BaseEventData data)
        {
            if (ignoreSelect)
            {
                ignoreSelect = false;
                return;
            }

            ShowSearchResults(Keyword);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void IptKeyword_OnDeselectEvent(BaseEventData data)
        {
            StartCoroutine(CheckOptionNextFrame());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        private void IptKeyword_OnValueChanged(string keyword)
        {
            if (ignoreChange)
            {
                ignoreChange = false;
                return;
            }
            ShowSearchResults(keyword);
        }

        /// <summary>
        /// 
        /// </summary>
        private void BtnSearch_OnClick()
        {
            if (string.IsNullOrEmpty(Keyword))
            {
                if (emptyMatchAll)
                {
                    if (scrSearch.gameObject.activeSelf)
                    {
                        scrSearch.gameObject.SetActive(false);
                    }
                    else
                    {
                        ShowSearchResults(Keyword);
                    }
                }
            }
            else
            {
                //Ipt_Keyword_OnValueChanged to ShowSearchResults.
                Keyword = string.Empty;
            }
            IptKeyword_Select();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void CollSearch_OnCellClickEvent(UIButtonCell cell)
        {
            scrSearch.gameObject.SetActive(false);
            var value = cell.text.text;
            lastSelect = value;
            IptKeyword_Set(value);
            OnCellClickEvent?.Invoke(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IEnumerator CheckOptionNextFrame()
        {
            yield return null;
            if (!IsSelectUIArea())
            {
                scrSearch.gameObject.SetActive(false);
                if (emptyKeepSelect && Keyword != lastSelect)
                {
                    IptKeyword_Set(lastSelect);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsSelectUIArea()
        {
            var select = EventSystem.current.currentSelectedGameObject;
            if (select == null)
            {
                return false;
            }

            if (select.transform.IsChildOf(iptKeyword.transform))
            {
                return true;
            }

            if (select.transform.IsChildOf(btnSearch.transform))
            {
                return true;
            }

            if (select.transform.IsChildOf(scrSearch.transform))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        protected void ShowSearchResults(string keyword)
        {
            SetSearchBtnOption(keyword);

            var selects = SearchDataItems(keyword);
            RefreshSearchItems(selects.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        protected void SetSearchBtnOption(string keyword)
        {
            var text = optSearch.text;
            var image = optSearch.image;
            if (!string.IsNullOrEmpty(keyword))
            {
                text = optClear.text;
                image = optClear.image;
            }
            txtSearch.text = text;
            imgSearch.sprite = image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        protected List<string> SearchDataItems(string keyword)
        {
            var matches = new List<string>();
            if (string.IsNullOrEmpty(keyword))
            {
                if (emptyMatchAll)
                {
                    matches.AddRange(items);
                }
                return matches;
            }

            var key = keyword.ToLower();
            foreach (var item in items)
            {
                if (item.ToLower().Contains(key))
                {
                    matches.Add(item);
                }
            }
            return matches;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        protected void RefreshSearchItems(string[] items)
        {
            if (items == null || items.Length == 0)
            {
                scrSearch.gameObject.SetActive(false);
                return;
            }

            var options = new List<UIButtonOptions>();
            foreach (var item in items)
            {
                options.Add(new UIButtonOptions() { text = item });
            }
            collSearch.Refresh(options);
            scrSearch.gameObject.SetActive(true);
        }
    }
}
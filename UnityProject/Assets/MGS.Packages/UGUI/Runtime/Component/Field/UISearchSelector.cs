/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UISearchSelector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Search-Selector.
    /// </summary>
    public class UISearchSelector : UIField
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected InputField ipt_Keyword;
        /// <summary>
        /// 
        /// </summary>
        protected Text txt_Caption;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Button btn_Search;
        /// <summary>
        /// 
        /// </summary>
        protected Text txt_Search;
        /// <summary>
        /// 
        /// </summary>
        protected Image img_Search;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected UIButtonCollectors coll_Search;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected bool emptyMatchAll;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Dropdown.OptionData opn_Search;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected Dropdown.OptionData opn_Clear;

        /// <summary>
        /// On select event (Index of the select item, value of the select item).
        /// </summary>
        public event Action<int, string> OnSelectEvent
        {
            add { onSelectEvent += value; }
            remove { onSelectEvent -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Action<int, string> onSelectEvent;

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
            set { ipt_Keyword.text = value; }
            get { return ipt_Keyword.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Caption
        {
            set { txt_Caption.text = value; }
            get { return txt_Caption.text; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected List<string> items = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            txt_Caption = ipt_Keyword.GetComponentInChildren<Text>();
            txt_Search = btn_Search.GetComponentInChildren<Text>();
            img_Search = btn_Search.GetComponent<Image>();
            coll_Search.RequireCanvasRaycasterGroup();

            var listener = ipt_Keyword.RequireSelectListener();
            listener.OnSelectEvent += Ipt_Keyword_OnSelectEvent; ;
            listener.OnDeselectEvent += Ipt_Keyword_OnDeselectEvent;
            ipt_Keyword.onValueChanged.AddListener(Ipt_Keyword_OnValueChanged);
            btn_Search.onClick.AddListener(Btn_Search_OnClick);
            //coll_Search.OnItemClickEvent += BtnCollector_OnItemClickEvent;
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
            Ipt_Keyword_Set(keyword);
            Caption = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="ignoreChange"></param>
        protected void Ipt_Keyword_Set(string content, bool ignoreChange = true)
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
        protected void Ipt_Keyword_Select(bool ignoreSelect = true)
        {
            this.ignoreSelect = ignoreSelect;
            ipt_Keyword.OnSelect(null);
            //this.ignoreSelect = false; //Ipt_Keyword_OnSelectEvent invoke after this method.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void Ipt_Keyword_OnSelectEvent(BaseEventData data)
        {
            if (ignoreSelect)
            {
                ignoreSelect = false; //Clear last tag.
                return;
            }

            ShowSearchResults(Keyword);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void Ipt_Keyword_OnDeselectEvent(BaseEventData data)
        {
            StartCoroutine(CheckOptionNextFrame());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        private void Ipt_Keyword_OnValueChanged(string keyword)
        {
            if (ignoreChange)
            {
                ignoreChange = false; //Clear last tag.
                return;
            }
            ShowSearchResults(keyword);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Btn_Search_OnClick()
        {
            if (string.IsNullOrEmpty(Keyword))
            {
                if (emptyMatchAll)
                {
                    if (coll_Search.gameObject.activeSelf)
                    {
                        coll_Search.gameObject.SetActive(false);
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
            Ipt_Keyword_Select();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void BtnCollector_OnItemClickEvent(int index, string value)
        {
            coll_Search.gameObject.SetActive(false);
            lastSelect = value;
            Ipt_Keyword_Set(value);
            ActionUtility.Invoke(onSelectEvent, index, value);
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
                if (coll_Search.gameObject.activeSelf)
                {
                    coll_Search.gameObject.SetActive(false);
                }
                if (Keyword != lastSelect)
                {
                    Ipt_Keyword_Set(lastSelect);
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

            if (select.transform.IsChildOf(ipt_Keyword.transform))
            {
                return true;
            }

            if (select.transform.IsChildOf(coll_Search.transform))
            {
                return true;
            }

            if (select.transform.IsChildOf(btn_Search.transform))
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
            var text = opn_Search.text;
            var image = opn_Search.image;
            if (!string.IsNullOrEmpty(keyword))
            {
                text = opn_Clear.text;
                image = opn_Clear.image;
            }
            txt_Search.text = text;
            img_Search.sprite = image;
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
            //coll_Search.Refresh(items);
            coll_Search.gameObject.SetActive(items.Length > 0);
        }
    }
}
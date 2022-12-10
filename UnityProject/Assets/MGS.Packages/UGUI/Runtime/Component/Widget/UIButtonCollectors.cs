/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIButtonCollector.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Common.Utility;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI Button-Collector.
    /// </summary>
    public class UIButtonCollectors : UIComponent
    {
        /// <summary>
        /// Root of button items.
        /// </summary>
        [SerializeField]
        protected RectTransform content;

        /// <summary>
        /// Prefab for item clone.
        /// </summary>
        [SerializeField]
        protected Button item;

        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected int maxCount = 5;

        /// <summary>
        /// 
        /// </summary>
        public int MaxCount
        {
            set { maxCount = value; }
            get { return maxCount; }
        }

        /// <summary>
        /// On item click event (Index of item, value of item).
        /// </summary>
        public event Action<int, string> OnItemClickEvent
        {
            add { onItemClickEvent += value; }
            remove { onItemClickEvent -= value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected Action<int, string> onItemClickEvent;

        /// <summary>
        /// Refresh button item for data items.
        /// </summary>
        /// <param name="items"></param>
        public void Refresh(string[] items)
        {
            var itemCount = 0;
            if (items != null)
            {
                itemCount = items.Length;
            }

            var childCount = content.childCount;
            while (childCount > itemCount)
            {
                content.GetChild(childCount - 1).gameObject.SetActive(false);
                childCount--;
            }
            while (childCount < itemCount)
            {
                Instantiate(item, content);
                childCount++;
            }

            for (int i = 0; i < itemCount; i++)
            {
                var item = content.GetChild(i).GetComponent<Button>();
                item.onClick.RemoveAllListeners();
                var index = i; var value = items[i];
                item.onClick.AddListener(() => Item_OnClick(index, value));

                item.GetComponentInChildren<Text>().text = value;
                item.gameObject.SetActive(true);
            }

            SetContentHeight(itemCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCount"></param>
        protected void SetContentHeight(int itemCount)
        {
            var rectHeight = 0f;
            var contentHeight = 0f;
            if (itemCount > 0)
            {
                var layout = content.GetComponent<VerticalLayoutGroup>();
                float padding = layout.padding.vertical;
                if (itemCount > 1)
                {
                    padding += layout.spacing * (itemCount - 1);
                }

                var itemHeight = (item.transform as RectTransform).rect.height;
                rectHeight = itemHeight * Mathf.Min(itemCount, maxCount) + padding;
                contentHeight = itemHeight * itemCount + padding;
            }

            RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectHeight);
            (content.transform as RectTransform).SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, contentHeight);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        private void Item_OnClick(int index, string value)
        {
            ActionUtility.Invoke(onItemClickEvent, index, value);
        }
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIHorTextRowPanel.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.UGUI
{
    /// <summary>
    /// UI HorText-Row-Panel.
    /// </summary>
    public class UIHorTextRowPanel : UIComponent
    {
        /// <summary>
        /// 
        /// </summary>
        [SerializeField]
        protected UIHorTextRowItem item;
        /// <summary>
        /// 
        /// </summary>
        public float LeftMaxWidth = 100;
        /// <summary>
        /// 
        /// </summary>
        public float RightMaxWidth = 100;

        /// <summary>
        /// 
        /// </summary>
        protected List<UIHorTextRowItem> items = new List<UIHorTextRowItem>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        public void Refresh(UIHorTextRowData[] datas)
        {
            if (datas == null || datas.Length == 0)
            {
                foreach (var item in items)
                {
                    item.gameObject.SetActive(false);
                }
                return;
            }

            var count = items.Count;
            while (count < datas.Length)
            {
                items.Add(Instantiate(item, transform));
                count++;
            }
            while (count > items.Count)
            {
                items[count - 1].gameObject.SetActive(false);
            }

            var leftPrdWidth = 0f;
            var rightPrdWidth = 0f;
            for (int i = 0; i < datas.Length; i++)
            {
                items[i].gameObject.SetActive(true);
                items[i].ResetLayout();
                items[i].Refresh(datas[i]);

                leftPrdWidth = Mathf.Max(leftPrdWidth, items[i].leftText.preferredWidth);
                rightPrdWidth = Mathf.Max(rightPrdWidth, items[i].rightText.preferredWidth);
            }

            leftPrdWidth = Mathf.Min(leftPrdWidth, LeftMaxWidth);
            rightPrdWidth = Mathf.Min(rightPrdWidth, RightMaxWidth);
            for (int i = 0; i < datas.Length; i++)
            {
                items[i].leftLayout.preferredWidth = leftPrdWidth;
                items[i].rightLayout.preferredWidth = rightPrdWidth;
            }
        }
    }
}
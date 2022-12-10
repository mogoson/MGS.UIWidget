/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIHorTextRowItem.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// UI HorText-Row-Item.
    /// </summary>
    public class UIHorTextRowItem : UIComponent
    {
        /// <summary>
        /// 
        /// </summary>
        public LayoutElement leftLayout;
        /// <summary>
        /// 
        /// </summary>
        public Text leftText;

        /// <summary>
        /// 
        /// </summary>
        [Space(5)]
        public LayoutElement rightLayout;
        /// <summary>
        /// 
        /// </summary>
        public Text rightText;

        /// <summary>
        /// 
        /// </summary>
        public void ResetLayout()
        {
            leftLayout.preferredWidth = -1;
            rightLayout.preferredWidth = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Refresh(UIHorTextRowData data)
        {
            leftText.text = data.tittle;
            rightText.text = data.content;
        }
    }
}
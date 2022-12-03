/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIHTextRowFitterDemo.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI.Demo
{
    public class UIHorTextRowPanelDemo : MonoBehaviour
    {
        public UIHorTextRowPanel textRowPanel;

        private void Start()
        {
            var datas = new UIHorTextRowData[]
            {
                new UIHorTextRowData("Test tittle:", "Test content"),
                new UIHorTextRowData("Test a long lengh tittle:", "Test content"),
                new UIHorTextRowData("Test tittle:", "Test a long lengh content")
            };
            textRowPanel.Refresh(datas);
        }
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UICustomCellDemo.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/23/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI.Demo
{
    public class UICustomCellDemo : UIRefreshable<UICustomCellDemoOptions>
    {
        public Image Image;
        public Text text;

        protected override void OnRefresh(UICustomCellDemoOptions options)
        {
            Image.color = options.color;
            text.text = options.message;
        }
    }

    [Serializable]
    public struct UICustomCellDemoOptions
    {
        public Color color;
        public string message;
    }
}
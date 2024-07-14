/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UISearchSelectorDemo.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/6/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI.Demo
{
    public class UISearchSelectDemo : MonoBehaviour
    {
        public UISearchSelectField selectField;

        private void Awake()
        {
            selectField.OnCellClickEvent += SearchField_OnCellClickEvent;
        }

        private void Start()
        {
            var items = new string[]
            {
                "0","01","012", "0123","01234","012345","0123456"
            };

            var caption = "Enter keywords...";
            selectField.Refresh(items, -1, caption);
        }

        private void SearchField_OnCellClickEvent(string value)
        {
            Debug.LogFormat("SearchField_OnCellClickEvent : value is {0}", value);
        }
    }
}
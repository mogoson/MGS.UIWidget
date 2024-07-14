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
using System.Collections;

namespace MGS.UGUI.Demo
{
    public class UITextDemo : MonoBehaviour
    {
        public UIText text;

        void Start()
        {
            StartCoroutine(DelayAppendText());
        }

        IEnumerator DelayAppendText()
        {
            var time = 0f;
            while (time < 3)
            {
                yield return new WaitForSeconds(1.0f);
                text.text += " this is text for test.";
                time += 1;
            }
        }
    }
}
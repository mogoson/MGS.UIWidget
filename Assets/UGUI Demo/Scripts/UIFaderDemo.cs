/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIFaderDemo.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UGUI.Demo
{
    public class UIFaderDemo : MonoBehaviour
    {
        public UIAlphaFader alphaFader;
        public UIScaleFader scaleFader;
        public UIPositionFader positionFader;
        public UIColorFader colorFader;
        private Vector3 pos;

        private void Awake()
        {
            pos = (positionFader.transform as RectTransform).anchoredPosition;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                alphaFader.StartFade(1, 0, 0.5f);
                scaleFader.StartFade(Vector3.one, Vector3.zero, 0.5f);
                positionFader.StartFade(pos, new Vector3(-50, pos.y, pos.z), 0.5f);
                colorFader.StartFade(Color.green, Color.red, 0.5f);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                alphaFader.StartFade(0, 1, 0.5f);
                scaleFader.StartFade(Vector3.zero, Vector3.one, 0.5f);
                positionFader.StartFade(new Vector3(-50, pos.y, pos.z), pos, 0.5f);
                colorFader.StartFade(Color.red, Color.green, 0.5f);
            }
        }
    }
}
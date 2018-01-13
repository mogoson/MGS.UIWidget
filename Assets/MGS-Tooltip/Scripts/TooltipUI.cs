/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  TooltipUI.cs
 *  Description  :  Control tooltip UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/13/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Developer.Tooltip
{
    [AddComponentMenu("Developer/Tooltip/TooltipUI")]
    [RequireComponent(typeof(Text), typeof(ContentSizeFitter))]
    public class TooltipUI : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Text UI to display tooltip.
        /// </summary>
        public Text textUI;

        /// <summary>
        /// Background RectTransform of tooltip UI.
        /// </summary>
        public RectTransform bgRect;

        /// <summary>
        /// ContentSizeFitter of tooltip UI.
        /// </summary>
        public ContentSizeFitter sizeFitter;
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            textUI = GetComponent<Text>();
            if (transform.childCount > 0)
                bgRect = transform.GetChild(0).GetComponent<RectTransform>();

            sizeFitter = GetComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }

        protected virtual void Update()
        {
            transform.position = GetUIPosition(Input.mousePosition);
        }

        /// <summary>
        /// Get screen position of tooltip UI.
        /// </summary>
        /// <param name="pointerPos">Screen position of mouse pointer.</param>
        /// <returns>Screen position of tooltip UI.</returns>
        protected virtual Vector2 GetUIPosition(Vector2 pointerPos)
        {
            //Calculate position of tooltip UI.
            var halfWidth = bgRect.rect.width * 0.5f;
            var halfHeight = bgRect.rect.height * 0.5f;
            var newX = pointerPos.x < Screen.width - bgRect.rect.width ? pointerPos.x + halfWidth : Screen.width - halfWidth;
            var newY = pointerPos.y < Screen.height - bgRect.rect.height ? pointerPos.y + halfHeight : Screen.height - halfHeight;
            return new Vector2(newX, newY);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Show tooltip UI.
        /// </summary>
        /// <param name="text">Tooltip text.</param>
        public virtual void Show(string text)
        {
            textUI.text = text;
            gameObject.SetActive(true);
            sizeFitter.SetLayoutHorizontal();
            sizeFitter.SetLayoutVertical();
        }

        /// <summary>
        /// Close tooltip UI.
        /// </summary>
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}
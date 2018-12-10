/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TooltipUI.cs
 *  Description  :  Define tooltip UI.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/13/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/8/2018
 *  Description  :  Extend and optimize.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace Mogoson.Tooltip
{
    /// <summary>
    /// Tooltip UI(UGUI).
    /// </summary>
    [AddComponentMenu("Mogoson/Tooltip/TooltipUI")]
    [RequireComponent(typeof(Text), typeof(ContentSizeFitter))]
    public class TooltipUI : Tooltip
    {
        #region Field and Property
        /// <summary>
        /// Text UI to display tooltip.
        /// </summary>
        public Text textUI;

        /// <summary>
        /// ContentSizeFitter of tooltip UI.
        /// </summary>
        public ContentSizeFitter sizeFitter;

        /// <summary>
        /// Background RectTransform of tooltip UI.
        /// </summary>
        public RectTransform background;
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            textUI = GetComponent<Text>();
            sizeFitter = GetComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            if (transform.childCount > 0)
            {
                background = transform.GetChild(0).GetComponent<RectTransform>();
            }
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
            var halfWidth = background.rect.width * 0.5f;
            var halfHeight = background.rect.height * 0.5f;
            var newX = pointerPos.x < Screen.width - background.rect.width ? pointerPos.x + halfWidth : Screen.width - halfWidth;
            var newY = pointerPos.y < Screen.height - background.rect.height ? pointerPos.y + halfHeight : Screen.height - halfHeight;
            return new Vector2(newX, newY);
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Show tooltip UI.
        /// </summary>
        /// <param name="text">Tooltip text.</param>
        public override void Show(string text)
        {
            textUI.text = text;
            gameObject.SetActive(true);
            sizeFitter.SetLayoutHorizontal();
            sizeFitter.SetLayoutVertical();
        }

        /// <summary>
        /// Close tooltip UI.
        /// </summary>
        public override void Close()
        {
            gameObject.SetActive(false);
        }
        #endregion
    }
}
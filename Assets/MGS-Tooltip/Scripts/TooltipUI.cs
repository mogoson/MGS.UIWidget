/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: TooltipUI.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/13/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.           TooltipUI              Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     6/13/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.Tooltip
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(ContentSizeFitter), typeof(Text))]
    [AddComponentMenu("Developer/Tooltip/TooltipUI")]
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
        /// ContentSizeFitter of tooltip UI root.
        /// </summary>
        public ContentSizeFitter csFitter;
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            textUI = GetComponent<Text>();
            csFitter = GetComponent<ContentSizeFitter>();
            bgRect = transform.GetChild(0).GetComponent<RectTransform>();
        }

        protected virtual void Update()
        {
            SetPosition(Input.mousePosition);
        }

        /// <summary>
        /// Set tooltip UI screen position.
        /// </summary>
        /// <param name="pointerPos">Mouse pointer screen position.</param>
        protected virtual void SetPosition(Vector2 pointerPos)
        {
            //Calculate position of tooltip UI.
            var halfWidth = bgRect.rect.width * 0.5f;
            var halfHeight = bgRect.rect.height * 0.5f;
            var newX = pointerPos.x < Screen.width - bgRect.rect.width ? pointerPos.x + halfWidth : Screen.width - halfWidth;
            var newY = pointerPos.y < Screen.height - bgRect.rect.height ? pointerPos.y + halfHeight : Screen.height - halfHeight;
            transform.position = new Vector2(newX, newY);
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
            csFitter.SetLayoutHorizontal();
            csFitter.SetLayoutVertical();
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
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextExtension.cs
 *  Description  :  Extension UI Text.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;
using UnityEngine.UI;

namespace MGS.UI.Widget
{
    /// <summary>
    /// Extension UI Text.
    /// </summary>
    public static class UITextExtension
    {
        /// <summary>
        /// Get clipping text content.
        /// </summary>
        /// <param name="text">Text component.</param>
        /// <param name="content">Origin content set to Text.</param>
        /// <param name="stamp">Stamp mark if clipped.</param>
        /// <returns>Clipping text content.</returns>
        public static string GetClippingText(this Text text, string content, string stamp = null)
        {
            if (string.IsNullOrEmpty(content))
            {
                return string.Empty;
            }

            var rectHeight = text.rectTransform.rect.height;
            var firstHeight = text.font.lineHeight + 2.0f;
            if (firstHeight > rectHeight)
            {
                return stamp;
            }

            var rectWidth = text.rectTransform.rect.width;
            text.font.RequestCharactersInTexture(content, text.fontSize, text.fontStyle);
            CharacterInfo info;
            text.font.GetCharacterInfo(content[0], out info, text.fontSize, text.fontStyle);
            if (info.advance > rectWidth)
            {
                return stamp;
            }

            var currentWidth = 0f;
            var lineHeight = text.font.lineHeight * text.lineSpacing + 2.0f;
            var currentHeight = firstHeight;
            for (int i = 0; i < content.Length; i++)
            {
                text.font.GetCharacterInfo(content[i], out info, text.fontSize, text.fontStyle);
                currentWidth += info.advance;
                if (currentWidth > rectWidth)
                {
                    currentWidth = info.advance;
                    currentHeight += lineHeight;
                    if (currentHeight > rectHeight)
                    {
                        var stampWidth = 0f;
                        if (!string.IsNullOrEmpty(stamp))
                        {
                            for (int j = 0; j < stamp.Length; j++)
                            {
                                text.font.GetCharacterInfo(stamp[j], out info, text.fontSize, text.fontStyle);
                                stampWidth += info.advance;
                            }
                        }

                        while (currentWidth + stampWidth > 0 && i >= 0)
                        {
                            text.font.GetCharacterInfo(content[i], out info, text.fontSize, text.fontStyle);
                            currentWidth -= info.advance;
                            i--;
                        }
                        content = content.Substring(0, i + 1) + stamp;
                        break;
                    }
                }
            }
            return content;
        }

        /// <summary>
        /// Set clipping text content.
        /// </summary>
        /// <param name="text">Text component.</param>
        /// <param name="content">Origin content set to Text.</param>
        /// <param name="stamp">Stamp mark if clipped.</param>
        public static void SetClippingText(this Text text, string content, string stamp = null)
        {
            text.text = text.GetClippingText(content, stamp);
        }
    }
}
/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TileLayoutGroup.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/4
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.UGUI
{
    /// <summary>
    /// Represents a layout group that arranges its child elements in a tile pattern.
    /// </summary>
    public class TileLayoutGroup : LayoutGroup, ILayoutGroup
    {
        List<List<RectTransform>> lines = new List<List<RectTransform>>();

        public override void SetLayoutHorizontal()
        {
            lines.Clear();

            var cursor = 0f;
            var width = (transform as RectTransform).rect.width;
            var columns = new List<RectTransform>();
            foreach (var child in rectChildren)
            {
                child.anchorMin = child.anchorMax = Vector2.up;
                if (cursor + child.rect.width <= width)
                {
                    columns.Add(child);
                }
                else
                {
                    lines.Add(columns);
                    columns = new List<RectTransform> { child };

                    cursor = 0;
                }

                var pos = Vector2.right * (cursor + child.rect.width * 0.5f);

                child.anchoredPosition = pos;
                cursor += child.rect.width;
            }
            lines.Add(columns);
        }

        public override void CalculateLayoutInputVertical() { }

        public override void SetLayoutVertical()
        {
            var cursor = 0f;
            foreach (var columns in lines)
            {
                var height = 0f;
                foreach (var child in columns)
                {
                    if (child.rect.height > height)
                    {
                        height = child.rect.height;
                    }
                }
                foreach (var child in columns)
                {
                    var pos = child.anchoredPosition;
                    pos.y = cursor - height * 0.5f;
                    child.anchoredPosition = pos;
                }
                cursor -= height;
            }
        }
    }
}
/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIHorTextRowData.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/29/2021
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.UGUI
{
    /// <summary>
    /// UI HorText-Row-Data.
    /// </summary>
    public class UIHorTextRowData
    {
        /// <summary>
        /// 
        /// </summary>
        public string tittle;
        /// <summary>
        /// 
        /// </summary>
        public string content;

        /// <summary>
        /// 
        /// </summary>
        public UIHorTextRowData() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tittle"></param>
        /// <param name="content"></param>
        public UIHorTextRowData(string tittle, string content)
        {
            this.tittle = tittle;
            this.content = content;
        }
    }
}
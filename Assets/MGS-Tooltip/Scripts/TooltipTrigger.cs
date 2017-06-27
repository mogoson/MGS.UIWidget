/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: TooltipTrigger.cs
 *  Author: Mogoson   Version: 1.0   Date: 6/13/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.        TooltipTrigger            Ignore.
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

    [RequireComponent(typeof(Collider))]
    [AddComponentMenu("Developer/Tooltip/TooltipTrigger")]
    public class TooltipTrigger : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Target tooltip UI of trigger.
        /// </summary>
        public TooltipUI UI;

        /// <summary>
        /// Tooltip message.
        /// </summary>
        [Multiline]
        public string text = "Tooltip";
        #endregion

        #region Protected Method
        protected virtual void Reset()
        {
            UI = FindObjectOfType<TooltipUI>();
        }//Reset()_end

        protected virtual void OnMouseEnter()
        {
            UI.Show(text);
        }//OnM...()_end

        protected virtual void OnMouseExit()
        {
            UI.Close();
        }//OnM...()_end
        #endregion
    }//class_end
}//namespace_end
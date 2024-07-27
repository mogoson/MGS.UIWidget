/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UIMirror.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UIWidget
{
    /// <summary>
    /// UI mirror.
    /// </summary>
    public class UIMirror : UIWidget, IUIMirror
    {
        [SerializeField]
        protected UIMirrorMode mode;

        public bool IsMirror { protected set; get; }

        public void SetMirror()
        {
            RTransform.SetPosition(mode);
            IsMirror = !IsMirror;
        }

        public void SetMirror(UIMirrorMode mode)
        {
            this.mode = mode;
            SetMirror();
        }
    }
}
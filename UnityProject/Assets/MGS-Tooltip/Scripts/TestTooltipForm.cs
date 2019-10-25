/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestTooltipForm.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  25/10/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UIForm;
using UnityEngine;

namespace MGS.Tooltip
{
    [AddComponentMenu("MGS/Tooltip/TestTooltipForm")]
    public class TestTooltipForm : MonoUIForm
    {
        #region Private Method
        private void Start()
        {
            UIFormManager.Instance.OpenForm<TestTooltipForm>();
        }
        #endregion

        #region Public Method
        public override bool Refresh(object data)
        {
            return true;
        }
        #endregion
    }
}
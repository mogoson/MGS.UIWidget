/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UITextEditor.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  11/12/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEditor;
using UnityEditor.UI;

namespace MGS.UGUI.Editors
{
    [CustomEditor(typeof(UIText), true)]
    public class UITextEditor : TextEditor
    {
        protected SerializedProperty maxWidth;
        protected SerializedProperty maxHeight;

        protected override void OnEnable()
        {
            base.OnEnable();
            maxWidth = serializedObject.FindProperty("maxWidth");
            maxHeight = serializedObject.FindProperty("maxHeight");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawCustomInspector();
        }

        protected virtual void DrawCustomInspector()
        {
            DrawToggleFloatProperty(maxWidth);
            DrawToggleFloatProperty(maxHeight);
            serializedObject.ApplyModifiedProperties();
        }

        protected void DrawToggleFloatProperty(SerializedProperty property, float defaultValue = 100)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            var isOn = EditorGUILayout.Toggle(property.displayName, property.floatValue >= 0);
            if (EditorGUI.EndChangeCheck())
            {
                property.floatValue = isOn ? defaultValue : -1;
            }
            if (isOn)
            {
                property.floatValue = EditorGUILayout.FloatField(property.floatValue);
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
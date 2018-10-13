/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UTP12a;
using UnityEditor;
using UnityEngine;

namespace UTP12aEditor
{
    [CustomEditor(typeof(MyComponent))]
    public class MyComponentEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("This is a custom editor.");

            DrawDefaultInspector();

            if(GUILayout.Button("Press Me"))
            {
                Debug.Log("Hello World");
            }
        }
    }
}
#endif

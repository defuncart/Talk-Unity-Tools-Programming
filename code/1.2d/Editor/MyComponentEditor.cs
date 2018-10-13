/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UTP12d;
using UnityEditor;
using UnityEngine;

namespace UTP12dEditor
{
    [CustomEditor(typeof(MyComponent))]
    public class MyComponentEditor : Editor
    {
        private SerializedProperty myIntProperty;
        private SerializedProperty myFloatProperty;
        private SerializedProperty myStringProperty;
        private bool shouldFoldOutGroup = false;

        private void OnEnable()
        {
            myIntProperty = serializedObject.FindProperty("myInt");
            myFloatProperty = serializedObject.FindProperty("myFloat");
            myStringProperty = serializedObject.FindProperty("myString");
        }

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();

            //update the serialized object
            serializedObject.Update();

            //determine if the fold-out group show be displayed
            shouldFoldOutGroup = EditorGUILayout.Foldout(shouldFoldOutGroup, "Seldom used variables");

            //if the fold-out group should be displayed, draw myInt, myFloat, myString
            if(shouldFoldOutGroup)
            {
                EditorGUILayout.PropertyField(myIntProperty);
                EditorGUILayout.PropertyField(myFloatProperty);
                EditorGUILayout.PropertyField(myStringProperty);
            }

            //apply any changes
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif

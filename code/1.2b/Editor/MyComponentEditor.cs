/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UTP12b;
using UnityEditor;
using UnityEngine;

namespace UTP12bEditor
{
    [CustomEditor(typeof(MyComponent))]
    public class MyComponentEditor : Editor
    {
        private SerializedProperty canAttackProperty;
        private SerializedProperty attackDamageProperty;

        private void OnEnable()
        {
            canAttackProperty = serializedObject.FindProperty("canAttack");
            attackDamageProperty = serializedObject.FindProperty("attackDamage");
        }

        public override void OnInspectorGUI()
        {
            //draw the default inspector
            DrawDefaultInspector();

            //update the serialized object
            serializedObject.Update();

            //if canAttack is true, draw attackDamageProperty
            if(canAttackProperty.boolValue)
            {
                EditorGUILayout.PropertyField(attackDamageProperty);
            }

            //apply any changes
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif

/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UTP12c;
using UnityEditor;
using UnityEngine;

namespace UTP12cEditor
{
    [CustomEditor(typeof(MyComponent))]
    public class MyComponentEditor : Editor
    {
        private SerializedProperty gameModeProperty;
        private SerializedProperty numberMovesProperty;
        private SerializedProperty pointsRequiredProperty;
        private SerializedProperty numberIngredientsProperty;
        private SerializedProperty numberJellyProperty;

        private void OnEnable()
        {
            gameModeProperty = serializedObject.FindProperty("gameMode");
            numberMovesProperty = serializedObject.FindProperty("numberMoves");
            pointsRequiredProperty = serializedObject.FindProperty("pointsRequired");
            numberIngredientsProperty = serializedObject.FindProperty("numberIngredients");
            numberJellyProperty = serializedObject.FindProperty("numberJelly");
        }

        public override void OnInspectorGUI()
        {
            //update the serialized object
            serializedObject.Update();

            //draw gameMode and numberMoves
            EditorGUILayout.PropertyField(gameModeProperty);
            EditorGUILayout.PropertyField(numberMovesProperty);

            //draw relevant fields for the different game modes
            if(gameModeProperty.enumValueIndex == 0) //moves
            {
                EditorGUILayout.PropertyField(pointsRequiredProperty);
            }
            else if(gameModeProperty.enumValueIndex == 1) //ingredients
            {
                EditorGUILayout.PropertyField(numberIngredientsProperty);
            }
            else //jelly
            {
                EditorGUILayout.PropertyField(pointsRequiredProperty);
                EditorGUILayout.PropertyField(numberJellyProperty);
            }

            //apply any changes
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif

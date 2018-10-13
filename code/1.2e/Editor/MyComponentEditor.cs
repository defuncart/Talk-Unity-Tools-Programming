/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UTP12e;
using UnityEditor;
using UnityEngine;

namespace UTP12eEditor
{
    [CustomEditor(typeof(MyComponent))]
    public class MyComponentEditor : Editor
    {
        private SerializedProperty spriteProperty;
        private SerializedProperty initialHealthProperty;
        private SerializedProperty speedProperty;

        private void OnEnable()
        {
            spriteProperty = serializedObject.FindProperty("sprite");
            initialHealthProperty = serializedObject.FindProperty("initialHealth");
            speedProperty = serializedObject.FindProperty("speed");
        }

        public override void OnInspectorGUI()
        {
            //update the serialized object
            serializedObject.Update();

            //draw the sprite
            EditorGUILayout.PropertyField(spriteProperty);

            //if the sprite is not null, get a reference to the asset's preview and draw this texture
            if(spriteProperty.objectReferenceValue != null)
            {
                Texture2D myTexture = AssetPreview.GetAssetPreview(spriteProperty.objectReferenceValue);
                GUILayout.Label(myTexture);
            }

            //draw initialHealth and speed
            EditorGUILayout.PropertyField(initialHealthProperty);
            EditorGUILayout.PropertyField(speedProperty);

            //apply any changes
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif

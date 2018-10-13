/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UTP31
{
    /// <summary>A custom editor window.</summary>
    public class CustomWindow : EditorWindow
    {
        //add a menu item named "Import Assets" to the Tools menu
        [MenuItem("Tools/Custom Window")]
        public static void ShowWindow()
        {
            //show existing window instance - if one doesn't exist, create one
            EditorWindow.GetWindow(typeof(CustomWindow));
        }

        /// <summary>Draws the window.</summary>
        private void OnGUI()
        {
            //draw a label
            GUILayout.Label("This is my custom window");
            //draw a button which, if triggered, prints to the console
            if(GUILayout.Button("Print Info")) { Debug.Log("Hello, World!"); }
        }
    }
}
#endif

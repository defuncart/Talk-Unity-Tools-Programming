/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DeFuncArtEditor
{
    /// <summary>A class which declares a clear console menu item.</summary>
    public static class ClearConsoleMenuItem
    {
        /// <summary>The clear console menu item name (shortcut SHIFT+ALT+C).</summary>
        private const string CLEAR_CONSOLE_MENU_ITEM = "Tools/Edit/Clear Console #&c";
        /// <summary>The menu item's priority.</summary>
        private const int PRIORITY = 50;

        /// <summary>Clears the console.</summary>
        [MenuItem(CLEAR_CONSOLE_MENU_ITEM, false, PRIORITY)]
        public static void ClearConsole()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
            System.Type type = assembly.GetType("UnityEditor.LogEntries");
            MethodInfo method = type.GetMethod("Clear");
            method.Invoke(new object(), null);
        }
    }
}
#endif
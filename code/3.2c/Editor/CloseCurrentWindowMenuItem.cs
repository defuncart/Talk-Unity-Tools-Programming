/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace DeFuncArtEditor
{
    /// <summary>A class which declares a close current window menu item.</summary>
    public static class CloseCurrentWindowMenuItem
    {
        /// <summary>The close current window menu item name (shortcut SHIFT+F4).</summary>
        private const string CLOSE_CURRENT_WINDOW_MENU_ITEM = "Tools/Edit/Close Current Window #F4";
        /// <summary>The close current window menu item name (shortcut SHIFT+F4).</summary>
        private const string TOGGLE_MAXIMIZE_CURRENT_WINDOW_MENU_ITEM = "Tools/Edit/Toggle Maximize Current Window &F4";
        /// <summary>The menu item's priority.</summary>
        private const int PRIORITY = 50;

        /// <summary>Locks the current inspector.</summary>
        [MenuItem(CLOSE_CURRENT_WINDOW_MENU_ITEM, false, PRIORITY)]
        public static void CloseCurrentWindow()
        {
            EditorWindow.focusedWindow.Close();
        }

        /// <summary>A validation method for CloseCurrentWindow.</summary>
        /// <returns><c>true</c>, if current window can be closed, <c>false</c> otherwise.</returns>
        [MenuItem(CLOSE_CURRENT_WINDOW_MENU_ITEM, true, PRIORITY)]
        public static bool CanCloseCurrentWindow()
        {
            //the current window can be closed if there is a focused window. could add other custom logic here (i.e. never close hierarchy etc.)
            return EditorWindow.focusedWindow != null;
        }

        /// <summary>Maximizes/Minimizes the current inspector.</summary>
        [MenuItem(TOGGLE_MAXIMIZE_CURRENT_WINDOW_MENU_ITEM, false, PRIORITY)]
        public static void ToggleMaximizeCurrentWindow()
        {
            EditorWindow.focusedWindow.maximized = !EditorWindow.focusedWindow.maximized;
        }

        /// <summary>A validation method for ToggleMaximizeCurrentWindow.</summary>
        /// <returns><c>true</c>, if current window can toggle maximize, <c>false</c> otherwise.</returns>
        [MenuItem(TOGGLE_MAXIMIZE_CURRENT_WINDOW_MENU_ITEM, true, PRIORITY)]
        public static bool CanToggleMaximizeCurrentWindow()
        {
            //the current window can toggle maximized if there is a focused window. could add other custom logic here (i.e. never on hierarchy etc.)
            return EditorWindow.focusedWindow != null;
        }
    }
}
#endif

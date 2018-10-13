/*
 *  Based on LockInspector.cs by baba-s (MIT License).
 *  https://github.com/baba-s/unity-shortcut-key-plus/blob/master/Assets/UnityShortcutKeyPlus/Editor/LockInspector.cs
 *  Altered by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DeFuncArtEditor
{
    /// <summary>A class which declares a toggle inspector debug mode menu item.</summary>
    public static class ToggleInspectorDebugModeMenuItem
    {
        /// <summary>The toggle debug mode menu item name (shortcut ALT+K).</summary>
        private const string TOGGLE_INSPECTOR_DEBUG_MODE_MENU_ITEM = "Tools/Edit/Toggle Inspector Debug Mode &k";
        /// <summary>The menu item's priority.</summary>
        private const int PRIORITY = 50;

        /// <summary>Locks the current inspector.</summary>
        [MenuItem(TOGGLE_INSPECTOR_DEBUG_MODE_MENU_ITEM, false, PRIORITY)]
        public static void ToggleInspectorDebugMode()
        {
            //determine if normal mode or debug mode is presently selected
            System.Type inspectorType = inspectorWindow.GetType();
            ActiveEditorTracker tracker = ActiveEditorTracker.sharedTracker;
            bool isNormal = tracker.inspectorMode == InspectorMode.Normal;
            string methodName = isNormal ? "SetDebug" : "SetNormal";

            //use reflection to enable normal/debug mode
            BindingFlags attr = BindingFlags.NonPublic | BindingFlags.Instance;
            MethodInfo methodInfo = inspectorType.GetMethod(methodName, attr);
            methodInfo.Invoke(inspectorWindow, null);
            tracker.ForceRebuild();
        }

        /// <summary>A validation method for ToggleInspectorDebugMode.</summary>
        /// <returns><c>true</c>, if the inspector's window debug mode can be toggled, <c>false</c> otherwise.</returns>
        [MenuItem(TOGGLE_INSPECTOR_DEBUG_MODE_MENU_ITEM, true, PRIORITY)]
        public static bool CanToggleInspectorDebugMode()
        {
            //the inspector's debug mode can be toggled if the inspector window is presently open
            return inspectorWindow != null;
        }

        /// <summary>A reference to the inspector window.</summary>
        private static EditorWindow inspectorWindow
        {
            get
            {
                EditorWindow[] windows = Resources.FindObjectsOfTypeAll<EditorWindow>();
                return ArrayUtility.Find(windows, c => c.GetType().Name == "InspectorWindow");
            }
        }
    }
}
#endif

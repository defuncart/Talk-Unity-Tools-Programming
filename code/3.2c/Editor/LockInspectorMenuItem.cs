/*
 *  Based on LockInspector.cs by baba-s (MIT License).
 *  https://github.com/baba-s/unity-shortcut-key-plus/blob/master/Assets/UnityShortcutKeyPlus/Editor/LockInspector.cs
 *  Altered by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace DeFuncArtEditor
{
    /// <summary>A class which declares a lock insepctor menu item.</summary>
    public static class LockInspectorMenuItem
    {
        /// <summary>The lock inspector menu item name (shortcut ALT+L).</summary>
        private const string LOCK_INSPECTOR_MENU_ITEM = "Tools/Edit/Lock Inspector &l";
        /// <summary>The menu item's priority.</summary>
        private const int PRIORITY = 50;

        /// <summary>Locks the current inspector.</summary>
        [MenuItem(LOCK_INSPECTOR_MENU_ITEM, false, PRIORITY)]
        public static void LockInspector()
        {
            ActiveEditorTracker tracker = ActiveEditorTracker.sharedTracker;
            tracker.isLocked = !tracker.isLocked;
            tracker.ForceRebuild();
        }

        /// <summary>A validation method for LockInspector.</summary>
        /// <returns><c>true</c>, if the inspector can be locked, <c>false</c> otherwise.</returns>
        [MenuItem(LOCK_INSPECTOR_MENU_ITEM, true, PRIORITY)]
        public static bool CanLockInspector()
        {
            //the inspector can be locked if there is a valid sharedTracker
            return ActiveEditorTracker.sharedTracker != null;
        }
    }
}
#endif

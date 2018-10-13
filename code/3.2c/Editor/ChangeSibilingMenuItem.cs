/*
 *  Based on ChangeSibiling.cs by baba-s (MIT License).
 *  https://github.com/baba-s/unity-shortcut-key-plus/blob/master/Assets/UnityShortcutKeyPlus/Editor/ChangeSibiling.cs
 *  Altered by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DeFuncArtEditor
{
    /// <summary>A class which declares move siblings up/down menu items.</summary>
    public static class ChangeSiblingsMenuItem
    {
        /// <summary>The move sibling up menu item name (shortcut ALT+UP).</summary>
        private const string MOVE_SIBLING_UP_MENU_ITEM = "Tools/Edit/Move Sibling Up &UP";
        /// <summary>The move sibling down menu item name (shortcut ALT+DOWN).</summary>
        private const string MOVE_SIBLING_DOWN_MENU_ITEM = "Tools/Edit/Move Sibling Down &DOWN";
        /// <summary>The menu item's priority.</summary>
        private const int PRIORITY = 11;

        /// <summary>Moves a sibling up.</summary>
        [MenuItem(MOVE_SIBLING_UP_MENU_ITEM, false, PRIORITY)]
        public static void MoveSiblingUp()
        {
            Selection.activeTransform.SetSiblingIndex(Selection.activeTransform.GetSiblingIndex() - 1);
        }

        /// <summary>A validation method for MoveSiblingUp.</summary>
        /// <returns><c>true</c>, if a sibling can be moved up, <c>false</c> otherwise.</returns>
        [MenuItem(MOVE_SIBLING_UP_MENU_ITEM, true, PRIORITY)]
        public static bool CanMoveSiblingUp()
        {
            //a sibling can be moved up if there is a valid selected transform which isn't the first sibling
            return Selection.activeTransform != null && Selection.activeTransform.GetSiblingIndex() > 0;
        }

        /// <summary>Locks the current inspector.</summary>
        [MenuItem(MOVE_SIBLING_DOWN_MENU_ITEM, false, PRIORITY)]
        public static void MoveSiblingDown()
        {
            Selection.activeTransform.SetSiblingIndex(Selection.activeTransform.GetSiblingIndex() + 1);
        }

        /// <summary>A validation method for MoveSiblingDown.</summary>
        /// <returns><c>true</c>, if a sibling can be moved down, <c>false</c> otherwise.</returns>
        [MenuItem(MOVE_SIBLING_DOWN_MENU_ITEM, true, PRIORITY)]
        public static bool CanMoveSiblingDown()
        {
            //a sibling can be moved down if there is a valid selected transform which isn't the last sibling
            if(Selection.activeTransform != null)
            {
                //if the trasnform is on the root of the scene, then it has no parent and the number of siblings is given by the number of root objects.
                //else if the transform has a parent, then the number of siblings is simply the number of children the parent has
                int numberOfSiblings = Selection.activeTransform.parent == null ?
                                                SceneManager.GetActiveScene().GetRootGameObjects().Length :
                                                Selection.activeTransform.parent.childCount;
                return Selection.activeTransform.GetSiblingIndex() < numberOfSiblings - 1;
            }
            return false;
        }
    }
}
#endif

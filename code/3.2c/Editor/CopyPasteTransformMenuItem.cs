/*
 *  Based on CopyPasteTransform.cs by baba-s (MIT License).
 *  https://github.com/baba-s/unity-shortcut-key-plus/blob/master/Assets/UnityShortcutKeyPlus/Editor/CopyPasteTransform.cs
 *  Altered by James Leahy. (c) 2018 DeFunc Art.
 *  https://github.com/defuncart/
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace DeFuncArtEditor
{
    /// <summary>A class which declares copy and paste transform menu items.</summary>
    public static class CopyPasteTransformMenuItem
    {
        /// <summary>The copy transform menu item name (shortcut ALT+C).</summary>
        private const string COPY_TRANSFORM_MENU_ITEM = "Tools/Edit/Copy Transform &c";
        /// <summary>The paste transform menu item name (shortcut ALT+C).</summary>
        private const string PASTE_TRANSFORM_MENU_ITEM = "Tools/Edit/Paste Transform &v";
        /// <summary>The menu item's priority.</summary>
        private const int PRIORITY = 0;

        /// <summary>A class represented the data of a transform.</summary>
        private class TransformData
        {
            /// <summary>The transform's local position.</summary>
            public Vector3 localPosition;
            /// <summary>The transform's local rotation.</summary>
            public Quaternion localRotation;
            /// <summary>The transform's local scale.</summary>
            public Vector3 localScale;

            /// <summary>Initializes a new instance of <see cref="T:DeFuncArtEditor.CopyPasteTransform.TransformData"/>.</summary>
            /// <param name="localPosition">The local position.</param>
            /// <param name="localRotation">The local rotation.</param>
            /// <param name="localScale">The local scale.</param>
            public TransformData(Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
            {
                this.localPosition = localPosition;
                this.localRotation = localRotation;
                this.localScale = localScale;
            }

            /// <summary>Initializes a new instance of <see cref="T:DeFuncArtEditor.CopyPasteTransform.TransformData"/>.</summary>
            /// <param name="transform">The transform.</param>
            public TransformData(Transform transform) : this(transform.localPosition, transform.localRotation, transform.localScale) {}
        }
        /// <summary>A reference to the current transform's data.</summary>
        private static TransformData transformData;

        /// <summary>Copies the transform of the current selected object.</summary>
        [MenuItem(COPY_TRANSFORM_MENU_ITEM, false, PRIORITY)]
        public static void Copy()
        {
            transformData = new TransformData(Selection.activeTransform);
        }

        /// <summary>A validation method for Copy.</summary>
        /// <returns><c>true</c>, if a transform can be copied, <c>false</c> otherwise.</returns>
        [MenuItem(COPY_TRANSFORM_MENU_ITEM, true, PRIORITY)]
        public static bool CanCopy()
        {
            //a transform can be copied if there is a selected game object (which has a valid transform)
            return Selection.activeTransform != null;
        }

        /// <summary>Pastes the current transform data onto all selected objects.</summary>
        [MenuItem(PASTE_TRANSFORM_MENU_ITEM, false, PRIORITY)]
        public static void Paste()
        {
            foreach(GameObject gameObject in Selection.gameObjects)
            {
                //firstly record an undo object
                Undo.RecordObject(gameObject.transform, "Paste Transform Values");
                //then paste the transform data
                gameObject.transform.localPosition = transformData.localPosition;
                gameObject.transform.localRotation = transformData.localRotation;
                gameObject.transform.localScale = transformData.localScale;
            }
        }

        /// <summary>A validation method for Paste.</summary>
        /// <returns><c>true</c>, if a transform can be pasted, <c>false</c> otherwise.</returns>
        [MenuItem(PASTE_TRANSFORM_MENU_ITEM, true, PRIORITY)]
        public static bool CanPaste()
        {
            //a transform can be pasted if transformData exists and at least one game object is selected
            return transformData != null && Selection.gameObjects != null && Selection.gameObjects.Length > 0;
        }
    }
}
#endif

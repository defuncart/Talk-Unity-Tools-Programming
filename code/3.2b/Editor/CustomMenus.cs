/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UTP32b
{
    public class CustomMenus
    {
        ///<summary>A menu item with hotkey ALT+SHIFT+D</summary>
        [MenuItem("Tools/MenuItemOne #&d")]
        public static void MenuItemOne() { }

        ///<summary>A menu item with hotkey D</summary>
        [MenuItem("Tools/MenuItemTwo _d")]
        public static void MenuItemTwo() { }
    }
}
#endif

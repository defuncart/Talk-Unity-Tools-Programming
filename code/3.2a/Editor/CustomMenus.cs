/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UTP32a
{
    public class CustomMenus
    {
      [MenuItem("Tools/Data/Delete")]
      public static void DeleteData()
      {
        PlayerPrefs.DeleteAll();
      }
    }
}
#endif

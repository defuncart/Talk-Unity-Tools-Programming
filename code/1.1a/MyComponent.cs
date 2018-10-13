/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
using UnityEngine;

namespace UTP11a
{
    public class MyComponent : MonoBehaviour
    {
        [Range(0, 100)][SerializeField]
        private int myInt = 10;
        [HideInInspector]
        private float myFloat = 3.14f;
    }
}

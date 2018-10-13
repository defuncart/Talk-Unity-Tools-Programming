/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
using UnityEngine;

namespace UTP12e
{
    public class MyComponent : MonoBehaviour
    {
        [SerializeField] private Sprite sprite = null;
        [Range(1, 100)][SerializeField] private int initialHealth = 50;
        [Range(5, 20)][SerializeField] private float speed = 5;
    }
}

/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
using UnityEngine;

namespace UTP11b
{
    public class MyComponent : MonoBehaviour
    {
        [Header("Health Settings")]
        [SerializeField] [Tooltip("Player's current Health")]
        private int currentHealth = 0;
        [SerializeField] [Tooltip("Player's max Health")]
        private int maxHealth = 100;

        [Space(30)]

        [SerializeField] [Tooltip("Player's speed")]
        private float speed = 10;
    }
}

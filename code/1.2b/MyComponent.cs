/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
using UnityEngine;

namespace UTP12b
{
    public class MyComponent : MonoBehaviour
    {
        [SerializeField, Range(1, 100)] int initialHealth = 100;
        [SerializeField] bool canAttack = false;
        [HideInInspector, SerializeField, Range(5, 30)] int attackDamage = 10;
    }
}

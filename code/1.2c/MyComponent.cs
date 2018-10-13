/*
 *  Written by James Leahy. (c) 2018 DeFunc Art.
 *  Unity Tools Programming GIC Poznań 2018
 *  https://github.com/defuncart/Talk-Unity-Tools-Programming
 */
using UnityEngine;

namespace UTP12c
{
    public class MyComponent : MonoBehaviour
    {
        public enum GameMode
        {
            Moves, Ingredients, Jelly
        }
        [SerializeField] private GameMode gameMode;
        [SerializeField] [Range(1, 50)] private int numberMoves = 15;
        [SerializeField] [Range(1000, 100000)] private int pointsRequired = 25000;
        [SerializeField] [Range(1, 5)] private int numberIngredients = 2;
        [SerializeField] [Range(1, 100)] private int numberJelly = 20;
    }
}

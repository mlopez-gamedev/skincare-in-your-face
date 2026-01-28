using System;
using Random = UnityEngine.Random;

namespace MiguelGameDev
{
    public static class ArrayExtensions
    {
        public static bool ContainsIndex<T>(T[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }

        public static bool Contains<T>(this T[] array, T element)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static T GetRandom<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }
        
        public static T[] Shuffle<T>(this T[] array)
        {
            for (var i = array.Length - 1; i > 0; i--)
            {
                var temp = array[i];
                var index = Random.Range(0, i + 1);
                array[i] = array[index];
                array[index] = temp;
            }

            return array;
        }

        public static T[] CloneArray<T>(this T[] array)
        {
            var newArray = new T[array.Length];
            Array.Copy(array, newArray, array.Length);
            return newArray;
        }
    }
}
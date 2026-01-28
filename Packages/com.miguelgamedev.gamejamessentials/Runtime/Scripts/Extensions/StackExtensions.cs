using System.Collections.Generic;
using UnityEngine;

namespace MiguelGameDev
{
    public static class StackExtensions
    {
        public static bool ContainsIndex<T>(this Stack<T> stack, int index)
        {
            return index >= 0 && index < stack.Count;
        }

        public static void AddRange<T>(this Stack<T> stack,
            IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                stack.Push(item);
            }
        }
        
        public static void Shuffle<T>(this Stack<T> stack)
        {
            var array = stack.ToArray();
            stack.Clear();
            stack.AddRange(array.Shuffle());
        }

        public static List<T> Pop<T>(this Stack<T> stack, int amount)
        {
            var popList = new List<T>(amount);
            for (int i = 0; i < amount; i++)
            {
                if (!stack.TryPop(out var pop))
                {
                    break;
                }
                
                popList.Add(pop);
            }

            return popList;
        }
    }
    
    public static class ListExtensions
    {
        public static bool ContainsIndex<T>(this List<T> list, int index)
        {
            return index >= 0 && index < list.Count;
        }

        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
        
        public static T Pop<T>(this List<T> list)
        {
            var item = list[^1];
            list.Remove(item);
            return item;
        }
        
        public static T[] Pop<T>(this List<T> list, int amount)
        {
            var array = new T[amount];   
            for (int i = 0; i < amount; i++)
            {
                var item = list[^1];
                list.Remove(item);
                array[i] = item;   
            }

            return array;
        }
        
        public static T Peek<T>(this List<T> list)
        {
            return list[^1];
        }
        
        public static T[] Peek<T>(this List<T> list, int amount)
        {
            var array = new T[amount];   
            for (int i = list.Count - 1; i < amount; --i)
            {
                array[i] = list[i];   
            }

            return array;
        }
    }
}
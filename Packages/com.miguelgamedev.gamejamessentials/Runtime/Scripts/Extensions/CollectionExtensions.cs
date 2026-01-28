using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MiguelGameDev
{
    public static class CollectionExtensions
    {
        public static T GetRandom<T>(this ICollection<T> collection)
        {
            int index = Random.Range(0, collection.Count);
            foreach (var item in collection)
            {
                --index;
                if (index == 0)
                {
                    return item;
                }
            }

            return default;
        }
        
        public static void AddRange<T>(this ICollection<T> collection,
            IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                collection.Add(item);
            }
        }

        public static void Shuffle<T>(this ICollection<T> collection)
        {
            var array = collection.ToArray();
            collection.Clear();
            collection.AddRange(array.Shuffle());
        }
    }
}
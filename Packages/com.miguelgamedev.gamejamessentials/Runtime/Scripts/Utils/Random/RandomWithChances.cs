using System.Collections.Generic;
using UnityEngine;

namespace MiguelGameDev
{
    public class RandomWithChances<T>
    {
        private Dictionary<T, float> _elementChances;
        private float _totalChances;

        public float TotalChances => _totalChances;

        public RandomWithChances(RandomPickChances<T>[] elementChancesList)
        {
            _elementChances = new Dictionary<T, float>(elementChancesList.Length);

            _totalChances = 0f;
            foreach (var pickChances in elementChancesList)
            {
                _elementChances.Add(pickChances.Pick, pickChances.Chances);
                _totalChances += pickChances.Chances;
            }
        }

        public RandomWithChances(Dictionary<T, float> elementChances)
        {
            _elementChances = elementChances;
            _totalChances = 0f;
            var e = elementChances.GetEnumerator();
            while (e.MoveNext())
            {
                _totalChances += e.Current.Value;
            }
            e.Dispose();
        }

        public T PickRandom()
        {
            float pickNumber = Random.Range(0, _totalChances);
            T pick = default;

            var totalChances = _totalChances;
            var e = _elementChances.GetEnumerator();
            while (e.MoveNext())
            {
                totalChances -= e.Current.Value;
                if (pickNumber >= totalChances)
                {
                    pick = e.Current.Key;
                    break;
                }
            }
            e.Dispose();
            return pick;
        }
    }
}
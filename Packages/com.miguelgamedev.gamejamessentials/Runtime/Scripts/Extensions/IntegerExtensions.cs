using UnityEngine;

namespace MiguelGameDev
{

    public static class IntegerExtensions
    {
        public static int Diff(this int a, int b)
        {
            return Mathf.Abs(a - b);
        }

        public static string ToTimeString(this int value, bool showSeconds = true)
        {
            return ((float)value).ToTimeString(showSeconds);
        }

        public static string ToTimeSpanString(this int value, bool showMinorZeros = true,
                string secsSuffix = "s", string minsSuffix = "m",
                string hoursSuffix = "h", string daysSuffix = "d")
        {
            return ((float)value).ToTimeSpanString(showMinorZeros,
                secsSuffix, minsSuffix, hoursSuffix, daysSuffix);
        }

        public static bool IsBetween(this int value, int a, int b)
        {
            return (value > a && value < b) || (value > b && value < a); 
        }
    }
}
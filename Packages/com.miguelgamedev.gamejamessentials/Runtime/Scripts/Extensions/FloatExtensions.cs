using UnityEngine;

namespace MiguelGameDev
{
    public static class FloatExtensions
    {
        public static float Diff(this float a, float b)
        {
            return Mathf.Abs(a - b);
        }

        public static string ToTimeString(this float value, bool showSeconds = true)
        {
            int hours = Mathf.FloorToInt(value / 3600);
            int mins = Mathf.FloorToInt((value / 60) % 60);

            if (showSeconds)
            {
                int secs = Mathf.FloorToInt(value % 60);
                return string.Format("{0:00}:{1:00}:{2:00}", hours, mins, secs);
            }
            else
            {
                return string.Format("{0:00}:{1:00}", hours, mins);
            }
        }

        public static string ToTimeSpanString(this float value, bool showMinorZeros = true,
                string secsSuffix = "s", string minsSuffix = "m",
                string hoursSuffix = "h", string daysSuffix = "d")
        {
            if (value <= 0)
            {
                return "0" + secsSuffix;
            }
            else
            {

                int hours = Mathf.FloorToInt(value / 3600);
                if (hours > 0)
                {
                    if (hours >= 24)
                    {
                        int days = Mathf.FloorToInt(hours / 24);
                        //hours = hours % 24;
                        hours = hours - days * 24; // Better performance
                        if (showMinorZeros || hours > 0)
                        {
                            return string.Format("{0}{1} {2}{3}", days, daysSuffix, hours, hoursSuffix);
                        }
                        else
                        {
                            return string.Format("{0}{1}", days, daysSuffix);
                        }
                    }
                    else
                    {

                        int mins = Mathf.FloorToInt((value / 60) % 60);
                        if (showMinorZeros || mins > 0)
                        {
                            return string.Format("{0}{1} {2:00}{3}", hours, hoursSuffix,
                                    mins, minsSuffix);
                        }
                        else
                        {
                            return string.Format("{0}{1}", hours, hoursSuffix);
                        }
                    }
                }
                else
                {
                    int mins = Mathf.FloorToInt(value / 60);
                    //double secs = value % 60;
                    double secs = value - mins * 60; // Better performance
                    if (mins > 0)
                    {
                        if (showMinorZeros || secs > 0)
                        {
                            return string.Format("{0}{1} {2:00}{3}", mins, minsSuffix, secs, secsSuffix);
                        }
                        else
                        {
                            return string.Format("{0}{1}", mins, minsSuffix);
                        }

                    }
                    else
                    {
                        return string.Format("{0:0.0}{1}", secs, secsSuffix);
                    }
                }
            }
        }

        public static bool IsBetween(this float value, float a, float b)
        {
            return (value > a && value < b) || (value > b && value < a);
        }
    }
}
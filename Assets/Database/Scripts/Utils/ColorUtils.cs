using System;
using UnityEngine;

namespace GameDatabase.Utils
{
    public static class ColorUtils
    {
        public static Color ColorFromString(string color)
        {
            if (string.IsNullOrEmpty(color) || color[0] != '#')
                return Color.white;

            var value = Convert.ToUInt32(color.Substring(1), 16);

            if (value <= 0xffffff)
                value |= 0xff000000;

            var b = (byte)(value & 0xff); value >>= 8;
            var g = (byte)(value & 0xff); value >>= 8;
            var r = (byte)(value & 0xff); value >>= 8;
            var a = (byte)(value & 0xff);

            return new Color32(r, g, b, a);
        }

        public static string ColorToString(Color color)
        {
            var c = (Color32)color;

            return "#" + (c.a < 0xff ? c.a.ToString("X2") : string.Empty) + c.r.ToString("X2") + c.g.ToString("X2") + c.b.ToString("X2");
        }

        public static string ValidateColorString(string color)
        {
            if (string.IsNullOrEmpty(color))
                return ColorWhite;

            var index = color[0] == '#' ? 1 : 0;
            try
            {
                var value = Convert.ToUInt32(color.Substring(index), 16);
                return "#" + (value > 0xffffff ? value.ToString("X8") : value.ToString("X6"));
            }
            catch (Exception e)
            {
                return ColorWhite;
            }
        }

        private const string ColorWhite = "#ffffff";
    }
}

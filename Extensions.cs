using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TokenManager
{
    internal static class KeyEventArgsExtensions
    {
        public static string ToDisplayString(this Keys _this)
        {
            KeyEventArgs keyArgs = new KeyEventArgs(_this);

            string alt = keyArgs.Alt ? "Alt + " : "";
            string control = keyArgs.Control ? "Control + " : "";
            string shift = keyArgs.Shift ? "Shift + " : "";
            string key = keyArgs.KeyCode.ToString();

            key = Replace(key, "oem", "", StringComparison.InvariantCultureIgnoreCase);
            key = Replace(key, "menu", "", StringComparison.InvariantCultureIgnoreCase);
            key = Replace(key, "controlkey", "", StringComparison.InvariantCultureIgnoreCase);
            key = Replace(key, "shiftkey", "", StringComparison.InvariantCultureIgnoreCase);

            //return (key.Length > 0) ? alt + control + shift + key : "";
            return alt + control + shift + key;
        }

        private static string Replace(string value, string oldString, string newString, StringComparison comparisonType)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            int startIndex = 0;
            while ((0 <= startIndex) && (startIndex < value.Length))
            {
                int nextIndex = value.IndexOf(oldString, startIndex, comparisonType);
                if (nextIndex >= 0)
                {
                    result.Append(value.Substring(startIndex, nextIndex - startIndex));
                    result.Append(newString);
                    startIndex = nextIndex + oldString.Length;
                }
                else
                {
                    result.Append(value.Substring(startIndex, value.Length - startIndex));
                    startIndex = -1;
                }
            }
            return result.ToString();
        }
    }

    internal static class StringExtensions
    {
        public static List<string> ToTokens(this string _this)
        {
            List<string> result = new List<string>();
            string[] tokens = _this.Split('\n');
            foreach (string token in tokens)
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    result.Add(token.Trim());
                }
            }
            return result;
        }
    }
}

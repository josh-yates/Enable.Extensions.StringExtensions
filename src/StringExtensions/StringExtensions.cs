using System;

namespace Enable.Extensions
{
    public static class StringExtensions
    {
        private const string Ellipsis = "…";

        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var firstChar = s[0];

            if (char.IsLower(firstChar))
            {
                return s;
            }

            firstChar = char.ToLowerInvariant(firstChar);

            return firstChar + s.Substring(1);
        }

        public static string PadWithZeros(this string s, int maxLengthExcludingPrefix, string prefix = null)
        {
            var output = !string.IsNullOrEmpty(s) ? s : string.Empty;

            while (output.Length < maxLengthExcludingPrefix)
            {
                output = "0" + output;
            }

            return !string.IsNullOrEmpty(prefix) ? prefix + output : output;
        }

        /// <summary>
        /// Returns the original string trimmed to the specified maximum length and appended with an ellipsis.
        /// If the original string length is less than or equal to the length specified then the original string is returned.
        /// </summary>
        public static string Trim(this string s, int maxLength, bool showEllipsis = true)
        {
            if (s != null)
            {
                var ellipsis = showEllipsis ? Ellipsis : string.Empty;
                s = s.Trim();

                var calculatedMaxLength = maxLength - ellipsis.Length;

                if (calculatedMaxLength < 0)
                {
                    calculatedMaxLength = 0;
                }

                if (s.Length > calculatedMaxLength)
                {
                    s = string.Concat(s.Substring(0, calculatedMaxLength).TrimEnd(), ellipsis);
                }
            }

            return s;
        }

        /// <summary>
        /// Returns only the first line of the specified string.
        /// </summary>
        public static string TrimFirstLine(this string s)
        {
            if (s != null)
            {
                var trimmed = s.TrimStart();
                var newLineIndex = trimmed.IndexOfAny(new char[] { '\r', '\n' });

                if (newLineIndex >= 0)
                {
                    trimmed = s.Substring(0, newLineIndex);
                }

                return trimmed;
            }

            return s;
        }

        /// <summary>
        /// Determines whether two specified strings have the same value.
        /// </summary>
        public static bool IsEqual(this string a, string b, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (string.IsNullOrEmpty(a))
            {
                return string.IsNullOrEmpty(b);
            }
            else
            {
                return string.Equals(a, b, stringComparison);
            }
        }

        /// <summary>
        /// Splits the specified string on whitespace character
        /// </summary>
        public static string[] SplitOnWhiteSpace(this string s)
        {
            return s.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

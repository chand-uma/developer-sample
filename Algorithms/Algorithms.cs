using System;
using System.Text;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        /// <summary>
        /// Calculates the factorial of a given integer n.
        /// </summary>
        /// <param name="n">The integer to calculate the factorial for. Must be between 0 and 12 inclusive.</param>
        /// <returns>The factorial of n as an integer.</returns>
        /// <exception cref="ArgumentException">Thrown when n is less than 0 or greater than 12.</exception>
        public static int GetFactorial(int n)
        {
            if (n < 0 || n > 12)
                throw new ArgumentException("n must be between 0 and 12 inclusive.");
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Formats a variable number of strings into a single string with separators.
        /// </summary>
        /// <param name="items">The array of strings to format.</param>
        /// <returns>A string with items separated by commas and "and" before the last item.</returns>
        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
                return "";
            var sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                if (i > 0)
                {
                    if (i == items.Length - 1)
                        sb.Append(" and ");
                    else
                        sb.Append(", ");
                }
                sb.Append(items[i] ?? "");
            }
            return sb.ToString();
        }
    }
}
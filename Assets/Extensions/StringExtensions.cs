using System;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Calculates the similarity of two strings by differing chars.
        /// </summary>
        /// <returns>Percent of similarity.</returns>
        /// <remarks>O (n*m)</remarks>>
        public static double CalculateSimilarity(this string source, string target)
        {
            if (source == null || (target == null)) return 0.0;
            if (source.Length == 0 || target.Length == 0) return 0.0;
            if (source == target) return 1.0;
   
            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return 1.0 - (double)stepsToSame / (double)Math.Max(source.Length, target.Length);
        }
        
        /// <summary>
        /// Measuring the difference between two strings.
        /// </summary>
        /// <returns>Number of different chars.</returns>
        /// <remarks>O (n*m)</remarks>>
        public static int ComputeLevenshteinDistance(this string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 0 : target.Length;

            if (string.IsNullOrEmpty(target))
                return source.Length;

            int n = source.Length;
            int m = target.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++) 
                d[i, 0] = i;
            for (int j = 1; j <= m; j++) 
                d[0, j] = j;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = target[j - 1] == source[i - 1] ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }

        public static bool CheckSpacesAroundEdges(this string str)
        {
            Regex startRegex = new Regex(@"^\s*");
            Regex endRegex = new Regex(@"\s*$");
            return startRegex.IsMatch(str) || endRegex.IsMatch(str);
        }

        public static string RemoveSpacesAroundEdges(this string str)
        {
            int strLength = str.Length;
            int initialNonSpaceCharIndex = 0;
            int finalNonSpaceCharIndex = strLength;

            for (int i = 0; i < strLength; i++)
            {
                if (char.IsWhiteSpace(str[i])) continue;
                initialNonSpaceCharIndex = i - 1;
                break;
            }

            for (int i = strLength - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(str[i])) continue;
                finalNonSpaceCharIndex = i + 1;
                break;
            }

            return str.Substring(initialNonSpaceCharIndex, finalNonSpaceCharIndex);
        }
    }
}
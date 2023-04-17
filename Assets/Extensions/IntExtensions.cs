using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class IntExtensions
    {
        #region Fields

        private static readonly Dictionary<int, string> ShortMoneySuffixes = new Dictionary<int, string>()
        {
            { 3, "k" },
            { 6, "m" },
            { 9, "b" },
            { 12, "s" },
        };

        #endregion
        
        #region Methods

        public static string FormatAsDefaultShortMoney(this int number, Dictionary<int, string> shortMoneySuffixes = default)
        {
            if (number < 1000) return $"${number}";
            int digitsNumber = Mathf.CeilToInt(Mathf.Log10(number));
            digitsNumber = Mathf.FloorToInt((float) digitsNumber / 3) * 3;

            shortMoneySuffixes ??= ShortMoneySuffixes;
            float divider = Mathf.Pow(10, digitsNumber);
            string shortNumber = $"{Mathf.FloorToInt(number / divider)}.{Mathf.RoundToInt(number % divider / divider * 100)}";
            if (shortMoneySuffixes.ContainsKey(digitsNumber)) 
                return $"${shortNumber}{shortMoneySuffixes[digitsNumber]}";
            return number.ToString();
        }

        #endregion
    }
}
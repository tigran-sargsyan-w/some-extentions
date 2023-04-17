using System.Collections.Generic;

namespace Extensions
{
    public static class GenericExtensions
    {
        #region Methods

        public static bool IsOneOf<T>(this T current, IReadOnlyList<T> items)
        {
            for (int i = 0; i < items.Count; i++)
                if (current.Equals(items[i])) return true;
            return false;
        }

        public static bool IsOneOf<T>(this T current, params T[] items) => 
            current.IsOneOf(items as IReadOnlyList<T>);

        #endregion
    }
}
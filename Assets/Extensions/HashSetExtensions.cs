using System.Collections.Generic;

namespace Extensions
{
    public static class HashSetExtensions
    {
        #region Methods

        /// <summary>
        /// Adds multiple elements to the HashSet.
        /// </summary>
        /// <param name="hashSet">Current HashSet</param>
        /// <param name="items">Target T range</param>
        /// <typeparam name="T">Generic type of HashSet</typeparam>
        /// <remarks>O(n+m) | O(m) in Unity2021+</remarks>
        public static void AddRange<T>(this HashSet<T> hashSet, IReadOnlyList<T> items)
        {
            int itemsNumber = items.Count;
#if UNITY_2021_1_OR_NEWER
            hashSet.EnsureCapacity(hashSet.Count + itemsNumber);
#endif
            for (int i = 0; i < itemsNumber; i++) 
                hashSet.Add(items[i]);
        }

        #endregion
    }
}
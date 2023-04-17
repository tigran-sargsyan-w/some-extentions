using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class IDictionaryExtension
    {
        /// <summary>
        /// Replaces the value by key, if present. If absent, adds a new.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static void AddOrReplace<T, U>(this IDictionary<T, U> current, T key, U value)
        {
            if (current.ContainsKey(key))
            {
                current[key] = value;
            }
            else
            {
                current.Add(key, value);
            }
        }

        /// <summary>
        /// Add value if dictionary not contains key.
        /// </summary>
        /// <remarks> O(1) | O(N) </remarks>
        public static void AddIfNotContains<T, U>(this IDictionary<T, U> current, T key, U value)
        {
            if (!current.ContainsKey(key)) current.Add(key, value);
        }
        
        public static void RemoveWithSuchValues<T, U>(this IDictionary<T, U> dictionary, Predicate<U> predicate)
        {
            T[] keysArray = dictionary.GetKeysArray();
            for (int i = 0; i < keysArray.Length; i++)
            {
                T currentKey = keysArray[i];
                U currentValue = dictionary[keysArray[i]];
                if (predicate.Invoke(currentValue)) 
                    dictionary.Remove(currentKey);
            }
        }
        
        public static void RemoveWithSuchKeys<T, U>(this IDictionary<T, U> dictionary, Predicate<T> predicate)
        {
            T[] keysArray = dictionary.GetKeysArray();
            for (int i = 0; i < keysArray.Length; i++)
            {
                T currentKey = keysArray[i];
                if (predicate.Invoke(currentKey)) 
                    dictionary.Remove(currentKey);
            }
        }

        public static T[] GetKeysArray<T, U>(this IDictionary<T, U> dictionary)
        {
            ICollection<T> keys = dictionary.Keys;
            T[] keysArray = new T[keys.Count];
            keys.CopyTo(keysArray, 0);
            return keysArray;
        }
    }
}
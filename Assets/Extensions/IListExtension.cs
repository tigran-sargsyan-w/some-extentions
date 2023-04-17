using System;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class IListExtension
    {
        #region Index
        
        /// <summary>
        /// Sets the first element of an list.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static T SetFirstItem<T>(this IList<T> list, T item)
        {
            return list[0] = item;
        }

        /// <summary>
        /// Sets the last element of an list.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static T SetLastItem<T>(this IList<T> list, T item)
        {
            return list[list.Count - 1] = item;
        }

        /// <summary>
        /// Removes the last element of an list.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static void RemoveLastItem<T>(this IList<T> list)
        {
            list.RemoveAt(list.Count - 1);
        }

        public static void RemoveSuch<T>(this IList<T> list, Predicate<T> predicate)
        {
            int i = 0;
            while (i < list.Count)
            {
                if (predicate.Invoke(list[i])) 
                    list.RemoveAt(i);
                else i++;
            }
        }

        #endregion
        
        #region Utils

        /// <summary>
        /// Converts the list of type T to an list of type U via casting. T must be inherited from U.
        /// </summary>
        /// <remarks> O(n) </remarks>
        public static List<U> Convert<T, U>(this IList<T> source)
            where T: U
        {
            List<U> result = new List<U>(source.Count);
            source.ListUpdate();
            
            for (int i = 0; i < source.Count; i++) 
                result[i] = source[i];

            return result;
        }
        
        /// <summary>
        /// Remove null objects from the list.
        /// </summary>
        /// <remarks> O(n) </remarks>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static void ListUpdate<T>(this IList<T> list)
        {
            if (typeof(T).IsSubclassOf(typeof(UnityEngine.Object)))
            {
                list.RemoveSuch(item => item as UnityEngine.Object == null);
            }
            else
            {
                list.RemoveSuch(item => item == null);
            }
        }

        #endregion
    }
}
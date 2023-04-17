using System;
using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Extensions
{
    public static class IReadOnlyListExtensions
    {
        #region Fields

        private const int LastIndexOffset = 1;
        private const int MinNumForClampIndex = 0;

        #endregion
        
        #region Index
        
        /// <summary>
        /// Checks if the current index is the last index of an readOnlyList.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static bool IsLastIndex<T>(this IReadOnlyList<T> readOnlyList, int index)
        {
            return readOnlyList.ContainsIndex(index) && readOnlyList.LastIndex() == index;
        }
        
        /// <summary>
        /// Checks if the readOnlyList not contains elements.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static bool IsNullOrEmpty<T>(this IReadOnlyList<T> readOnlyList) => 
            readOnlyList.IsNull() || readOnlyList.Count < 1;
        
        /// <summary>
        /// Last index of the element that exists in the readOnlyList.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static int LastIndex<T>(this IReadOnlyList<T> readOnlyList) => 
            Mathf.Clamp(readOnlyList.Count - LastIndexOffset, MinNumForClampIndex, int.MaxValue);

        /// <summary>
        /// Checks if the readOnlyList contains the target index.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static bool ContainsIndex<T>(this IReadOnlyList<T> readOnlyList, int index) => 
            readOnlyList.Count > index;
        
        /// <summary>
        /// Returns a random element of the array.
        /// </summary>
        /// <remarks> O(1) </remarks>
        public static T GetRandomItem<T>(this IReadOnlyList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Returns a random element that matches the parameters given by predicate.
        /// </summary>
        /// <remarks> O(n) </remarks>
        public static T GetRandomWhere<T>(this IReadOnlyList<T> list, Predicate<T> predicate)
        {
            List<T> filteredList = new List<T>(list.Count);
            T current = default;
            for (int i = 0; i < list.Count; i++)
            {
                current = list[i];
                if (predicate.Invoke(list[i])) filteredList.Add(current);
            }

            if (filteredList.IsNullOrEmpty()) return default;
            return filteredList[UnityEngine.Random.Range(0, filteredList.Count)];
        }

        public static bool ExistItem<T>(this IReadOnlyList<T> list, Predicate<T> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            for (int i = 0; i < list.Count; i++)
                if (predicate(list[i]))
                    return true;

            return false;
        }

        #endregion
        
        #region Utils

        /// <summary>
        /// Executes the method passing each of the list elements as an argument.
        /// </summary>
        /// <remarks> O(n) </remarks>
        /// <remarks> Ignores null elements. </remarks>
        public static void DoWithEveryone<T>(this IReadOnlyList<T> list, Action<T> action)
        {
            for (int i = 0; i < list.Count; i++) 
                action?.Invoke(list[i]);
        }

        #endregion

        #region Unity classes

        /// <summary>
        /// Sets the parent of each Transform.
        /// /</summary>
        /// <remarks> O(n) </remarks>
        public static void SetParentAll<T>(this IReadOnlyList<T> list, Transform parent)
            where T : Transform
        {
            for (int i = 0; i < list.Count; i++) 
                list[i].parent = parent;
        }

        /// <summary>
        /// Detaches each element from its parent and moves to the top of the hierarchy.
        /// /</summary>
        /// <remarks> O(n) </remarks>
        public static void UnparentAll<T>(this IReadOnlyList<T> list)
            where T : Transform
        {
            for (int i = 0; i < list.Count; i++) 
                list[i].parent = null;
        }

        /// <summary>
        /// Executes the SetActive() method on each GameObject.
        /// /</summary>
        /// <remarks> O(n) </remarks>
        public static void SetActiveAll(this IReadOnlyList<GameObject> list, bool state)
        {
            for (int i = 0; i < list.Count; i++) 
                list[i].SetActive(state);
        }

        /// <summary>
        /// Sets activity for each element inherited from MonoBehaviour.
        /// /</summary>
        /// <remarks> O(n) </remarks>
        public static void SetEnabled<T>(this IReadOnlyList<T> list, bool state)
            where T : MonoBehaviour
        {
            for (int i = 0; i < list.Count; i++) 
                list[i].enabled = state;
        }

        /// <summary>
        /// Destroys every non-null element inherited from UnityEngine.Object.
        /// /</summary>
        /// <remarks> O(n) </remarks>
        public static void DestroyAllNotNull<T>(this IReadOnlyList<T> list)
            where T : UnityEngine.Object
        {
            for (int i = 0; i < list.Count; i++) 
                list[i].DestroyNotNull();
        }

        #endregion
    }
}
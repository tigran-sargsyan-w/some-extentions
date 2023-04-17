using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class IEnumerableExtensions
    {
        #region Methods

        public static TOutCollection GetChildrenCollection<T, TOut, TOutCollection>(this IEnumerable<T> collection,
            Func<T, TOut> getChildFunc)
            where TOutCollection : ICollection<TOut>, new()
        {
            TOutCollection result = new TOutCollection();
            foreach (T item in collection)
            {
                TOut childItem = getChildFunc.Invoke(item);
                result.Add(childItem);
            }
            
            return result;
        }

        #endregion
    }
}
using UnityEngine;

namespace Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNull(this object obj)
        {
            if (obj is UnityEngine.Object uniObj) 
                return uniObj == null || (object) uniObj == null;
            return obj == null;
        }
        
        public static bool NotNull(this object obj)
        {
            if (obj is UnityEngine.Object uniObj) 
                return uniObj != null && (object) uniObj != null;
            return obj != null;
        }
        
        public static bool LogIfNull(this object obj, string message = "Object is null")
        {
            if (obj.IsNull())
            {
                Debug.LogWarning(message);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks and prints the result to the console.
        /// </summary>
        /// <returns> Result of checking. </returns>
        public static bool LogNotNull(this object obj, string message = "Object is null")
        {
            if (obj.IsNull())
            {
                Debug.LogWarning(message);
                return false;
            }

            return true;
        }
    }
}
using Extensions;
using UnityEngine;

namespace Extensions
{
    public static class UnityObjectExtension
    {
        /// <summary>
        /// Destroys the object if it is not null.
        /// </summary>
        public static void DestroyNotNull<T>(this T obj)
            where T : UnityEngine.Object
        {
            if (obj.NotNull()) UnityEngine.Object.Destroy(obj);
        }
        
        /// <summary>
        /// Destroys GameObject if MonoBehaviour not null.
        /// </summary>
        public static void TryDestroyGameObject<T>(this T behaviour)
            where T : MonoBehaviour
        {
            if (behaviour.NotNull())
                behaviour.gameObject.DestroyNotNull();
        }
    }
}
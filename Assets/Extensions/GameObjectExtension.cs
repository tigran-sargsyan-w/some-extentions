using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtension
    {
        public static void Parent(this GameObject gameObject, Transform parent)
        {
            gameObject.transform.parent = parent;
        }
        
        public static void Unparent(this GameObject gameObject)
        {
            gameObject.transform.parent = null;
        }
    }
}
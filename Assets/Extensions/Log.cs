using UnityEngine;

namespace Extensions
{
    public static class Log
    {
        public static void NoEventListener()
        {
            Debug.LogWarning("Event has no listeners.");
        }

        public static void NoEventListener(string eventName)
        {
            Debug.LogWarning($"{eventName} has no listeners.");
        }
    }
}
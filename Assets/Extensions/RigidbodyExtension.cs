using UnityEngine;

namespace Extensions
{
    public static class RigidbodyExtension
    {
        /// <summary>
        /// Clamps the velocity between the given minimum float and maximum float values.
        /// </summary>
        public static void ClampVelocity(this Rigidbody rigidbody, float min, float max)
        {
            rigidbody.velocity = new Vector3
            {
                x = Mathf.Clamp(rigidbody.velocity.x, min, max),
                y = Mathf.Clamp(rigidbody.velocity.y, min, max),
                z = Mathf.Clamp(rigidbody.velocity.z, min, max)
            };
        }
        
        /// <summary>
        /// Sets the speed in each direction between the specified minimum and maximum values of the corresponding vector values.
        /// </summary>
        public static void ClampVelocity(this Rigidbody rigidbody, Vector3 min, Vector3 max)
        {
            rigidbody.velocity = new Vector3
            {
                x = Mathf.Clamp(rigidbody.velocity.x, min.x, max.x),
                y = Mathf.Clamp(rigidbody.velocity.y, min.y, max.y),
                z = Mathf.Clamp(rigidbody.velocity.z, min.z, max.z)
            };
        }
    }
}
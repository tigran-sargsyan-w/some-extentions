using UnityEngine;

namespace Extensions
{
    public static class Rigidbody2DExtension
    {
        /// <summary>
        /// Clamps the velocity between the given minimum float and maximum float values.
        /// </summary>
        public static void ClampVelocity(this Rigidbody2D rigidbody, float min, float max)
        {
            rigidbody.velocity = new Vector2
            {
                x = Mathf.Clamp(rigidbody.velocity.x, min, max),
                y = Mathf.Clamp(rigidbody.velocity.y, min, max)
            };
        }
        
        /// <summary>
        /// Sets the speed in each direction between the specified minimum and maximum values of the corresponding vector values.
        /// </summary>
        public static void ClampVelocity(this Rigidbody2D rigidbody, Vector2 min, Vector2 max)
        {
            rigidbody.velocity = new Vector2
            {
                x = Mathf.Clamp(rigidbody.velocity.x, min.x, max.x),
                y = Mathf.Clamp(rigidbody.velocity.y, min.y, max.y)
            };
        }
    }
}
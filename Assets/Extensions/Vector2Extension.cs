using UnityEngine;

namespace Extensions
{
    public static class Vector2Extension
    {
        /// <summary>
        /// Rotates the current vector by Quaternion.
        /// </summary>
        public static Vector2 Rotate(this Vector2 vector2, Quaternion rotation)
        {
            return rotation * vector2;
        }

        /// <summary>
        /// Rotates the current vector converting the Vector3 argument to Quaternion.
        /// </summary>
        public static Vector2 Rotate(this Vector2 vector2, Vector3 rotation)
        {
            return Quaternion.Euler(rotation) * vector2;
        }

        /// <summary>
        /// Adds a float value to each component of the vector.
        /// </summary>
        public static void Add(this Vector2 vector2, float value)
        {
            vector2.Set(vector2.x + value, vector2.y + value);
        }

        /// <summary>
        /// Subtracts the float value from each component vector.
        /// </summary>
        public static void Sub(this Vector2 vector2, float value)
        {
            vector2.Set(vector2.x - value, vector2.y - value);
        }
        
        /// <summary>
        /// Clamps the Vector2 parameters between the given minimum and maximum float values.
        /// </summary>
        public static Vector2 Clamp(this Vector2 vector2, float min, float max)
        {
            return new Vector2
            {
                x = Mathf.Clamp(vector2.x, min, max),
                y = Mathf.Clamp(vector2.y, min, max)
            };
        }
        
        /// <summary>
        /// Clamps the Vector2 parameters between the given minimum and maximum Vector2 values.
        /// </summary>
        public static Vector2 Clamp(this Vector2 vector2, Vector2 min, Vector2 max)
        {
            return new Vector2
            {
                x = Mathf.Clamp(vector2.x, min.x, max.x),
                y = Mathf.Clamp(vector2.y, min.y, max.y)
            };
        }
        
        /// <summary>
        /// Clamps the Vector2.x parameter between the given minimum and maximum float values.
        /// </summary>
        public static Vector2 ClampX(this Vector2 vector2, float min, float max)
        {
            return new Vector2
            {
                x = Mathf.Clamp(vector2.x, min, max),
                y = vector2.y
            };
        }
        
        /// <summary>
        /// Clamps the Vector2.y parameter between the given minimum and maximum float values.
        /// </summary>
        public static Vector2 ClampY(this Vector2 vector2, float min, float max)
        {
            return new Vector2
            {
                x = vector2.x,
                y = Mathf.Clamp(vector2.y, min, max)
            };
        }
        
        public static Vector2 SetX(this Vector2 vector2, float value)
        {
            return new Vector2
            {
                x = value,
                y = vector2.y
            };
        }
        
        public static Vector2 SetY(this Vector2 vector2, float value)
        {
            return new Vector2
            {
                x = vector2.x,
                y = value
            };
        }
    }
}
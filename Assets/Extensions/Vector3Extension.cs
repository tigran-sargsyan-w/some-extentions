using UnityEngine;

namespace Extensions
{
    public static class Vector3Extension
    {
        /// <summary>
        /// Rotates the current vector by Quaternion.
        /// </summary>
        public static Vector3 Rotate(this Vector3 vector3, Quaternion rotation)
        {
            return rotation * vector3;
        }

        /// <summary>
        /// Rotates the current vector converting the Vector3 argument to Quaternion.
        /// </summary>
        public static Vector3 Rotate(this Vector3 vector3, Vector3 rotation)
        {
            return vector3.Rotate(Quaternion.Euler(rotation));
        }

        /// <summary>
        /// Multiply each component of the vectors.
        /// </summary>
        public static Vector3 Multiply(this Vector3 a, Vector3 b)
        {
            return new Vector3
            {
                x = a.x * b.x,
                y = a.y * b.y,
                z = a.z * b.z,
            };
        }

        /// <summary>
        /// Adds a float value to each component of the vector.
        /// </summary>
        public static Vector3 Add(this Vector3 vector3, float value)
        {
            return new Vector3(vector3.x + value, vector3.y + value, vector3.z + value);
        }

        /// <summary>
        /// Adds a float value to X component of the vector.
        /// </summary>
        public static Vector3 AddX(this Vector3 vector3, float value)
        {
            return new Vector3(vector3.x + value, vector3.y, vector3.z);
        }

        /// <summary>
        /// Adds a float value to Y component of the vector.
        /// </summary>
        public static Vector3 AddY(this Vector3 vector3, float value)
        {
            return new Vector3(vector3.x, vector3.y + value, vector3.z);
        }

        /// <summary>
        /// Adds a float value to Z component of the vector.
        /// </summary>
        public static Vector3 AddZ(this Vector3 vector3, float value)
        {
            return new Vector3(vector3.x, vector3.y, vector3.z + value);
        }

        /// <summary>
        /// Subtracts the float value from each component vector.
        /// </summary>
        public static Vector3 Sub(this Vector3 vector3, float value)
        {
            return new Vector3(vector3.x - value, vector3.y - value, vector3.z - value);
        }
        
        /// <summary>
        /// Clamps the Vector3 parameters between the given minimum and maximum float values.
        /// </summary>
        public static Vector3 Clamp(this Vector3 vector3, float min, float max)
        {
            return new Vector3
            {
                x = Mathf.Clamp(vector3.x, min, max),
                y = Mathf.Clamp(vector3.y, min, max),
                z = Mathf.Clamp(vector3.z, min, max)
            };
        }
        
        /// <summary>
        /// Clamps the Vector3 parameters between the given minimum and maximum Vector3 values.
        /// </summary>
        public static Vector3 Clamp(this Vector3 vector3, Vector3 min, Vector3 max)
        {
            return new Vector3
            {
                x = Mathf.Clamp(vector3.x, min.x, max.x),
                y = Mathf.Clamp(vector3.y, min.y, max.y),
                z = Mathf.Clamp(vector3.z, min.z, max.z)
            };
        }
        
        /// <summary>
        /// Clamps the Vector3.x parameter between the given minimum and maximum float values.
        /// </summary>
        public static Vector3 ClampX(this Vector3 vector3, float min, float max)
        {
            return new Vector3
            {
                x = Mathf.Clamp(vector3.x, min, max),
                y = vector3.y,
                z = vector3.z
            };
        }
        
        /// <summary>
        /// Clamps the Vector3.y parameter between the given minimum and maximum float values.
        /// </summary>
        public static Vector3 ClampY(this Vector3 vector3, float min, float max)
        {
            return new Vector3
            {
                x = vector3.x,
                y = Mathf.Clamp(vector3.y, min, max),
                z = vector3.z
            };
        }
        
        /// <summary>
        /// Clamps the Vector3.z parameter between the given minimum and maximum float values.
        /// </summary>
        public static Vector3 ClampZ(this Vector3 vector3, float min, float max)
        {
            return new Vector3
            {
                x = vector3.x,
                y = vector3.y,
                z = Mathf.Clamp(vector3.z, min, max),
            };
        }
        
        public static Vector3 SetX(this Vector3 vector3, float value)
        {
            return new Vector3
            {
                x = value,
                y = vector3.y,
                z = vector3.z
            };
        }
        
        public static Vector3 SetY(this Vector3 vector3, float value)
        {
            return new Vector3
            {
                x = vector3.x,
                y = value,
                z = vector3.z
            };
        }
        
        public static Vector3 SetZ(this Vector3 vector3, float value)
        {
            return new Vector3
            {
                x = vector3.x,
                y = vector3.y,
                z = value
            };
        }
    }
}
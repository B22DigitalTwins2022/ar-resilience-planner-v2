using UnityEngine;
using System.Collections;

namespace ShapeReality.Utils
{
	/// <summary>
    /// Simple extensions, e.g. for setting individual components of the vectors
    /// </summary>
	public static class VectorExtensions
	{
        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }

        public static bool RoughlyEquals(this Vector3 vector, Vector3 vector2)
        {
            return Vector3.Distance(vector, vector2) < Mathf.Epsilon;
        }
    }
}


using UnityEngine;
using System.Collections;

namespace ShapeReality.Utils
{
    /// <summary>
    /// Static methods for smooth interpolation for extra polish
    /// </summary>
    public static class Smoothing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="output"></param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        public static bool Interpolate(float current, float target, out float output, float smoothTime)
        {
            if (Mathf.Abs(target - current) > Mathf.Epsilon)
            {
                var velocity = 0.0f;
                output = Mathf.SmoothDamp(current, target, ref velocity, smoothTime);
                return true;
            }
            output = 0;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="output"></param>
        /// <param name="smoothTime"></param>
        /// <returns></returns>
        public static bool Interpolate(Vector3 current, Vector3 target, out Vector3 output, float smoothTime)
        {
            if (Vector3.Distance(target, current) > Mathf.Epsilon)
            {
                var velocity = Vector3.zero;
                output = Vector3.SmoothDamp(current, target, ref velocity, smoothTime);
                return true;
            }
            output = Vector3.zero;
            return false;
        }
    }
}
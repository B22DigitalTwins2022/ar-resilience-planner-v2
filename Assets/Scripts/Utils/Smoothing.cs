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
            if (!target.RoughlyEquals(current))
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
            if (!target.RoughlyEquals(current))
            {
                var velocity = Vector3.zero;
                output = Vector3.SmoothDamp(current, target, ref velocity, smoothTime);
                return true;
            }
            output = Vector3.zero;
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
        public static bool Interpolate(TransformValues current, TransformValues target, out TransformValues output, float smoothTime)
        {
            output = TransformValues.Zero;
            if (!target.RoughlyEquals(current))
            {
                var positionVelocity = Vector3.zero;
                var rotationVelocity = Quaternion.identity;
                var scaleVelocity = Vector3.zero;
                
                output.Position = Vector3.SmoothDamp(current.Position, target.Position, ref positionVelocity, smoothTime);
                output.Scale = Vector3.SmoothDamp(current.Scale, target.Scale, ref scaleVelocity, smoothTime);
                output.Rotation = QuaternionExtensions.SmoothDamp(current.Rotation, target.Rotation, ref rotationVelocity, smoothTime);
                return true;
            }
            return false;
        }
    }
}
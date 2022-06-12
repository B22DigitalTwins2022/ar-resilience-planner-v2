using System;
using UnityEngine;

namespace ShapeReality.Utils
{
    public static class TransformExtensions
    {
        public static void SetFromValues(this Transform transform, TransformValues values)
        {
            transform.SetPositionAndRotation(values.Position, values.Rotation);
            transform.localScale = values.Scale;
        }
    }

    public struct TransformValues
    {
        public TransformValues(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        public TransformValues(Transform transform)
        {
            Position = transform.position;
            Rotation = transform.rotation;
            Scale = transform.lossyScale;
        }

        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }



        /*public bool RoughlyEquals(TransformValues transform2)
        {
            return Position.RoughlyEquals(transform2.Position) &&
                Scale.RoughlyEquals(transform2.Scale) &&
                Rotation.RoughlyEquals(transform2.Rotation);
        }*/

        public static TransformValues Zero
        {
            get => new(Vector3.zero, Quaternion.identity, Vector3.zero);
        }
    }
}

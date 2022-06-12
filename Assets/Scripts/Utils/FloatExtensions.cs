using UnityEngine;
using System.Collections;

namespace ShapeReality.Utils
{
	public static class FloatExtensions
	{
		public static bool RoughlyEquals(this float value, float value2)
        {
			return Mathf.Abs(value2 - value) < Mathf.Epsilon;
		}
	}
}


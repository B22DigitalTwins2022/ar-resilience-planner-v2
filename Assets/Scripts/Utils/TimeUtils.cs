using UnityEngine;
using System.Collections;

namespace ShapeReality.Utils
{
	public static class TimeUtils
	{
		public static float TimeMultiplier => Time.deltaTime * Constants.Values.DELTATIME_MULTIPLIER;
	}
}

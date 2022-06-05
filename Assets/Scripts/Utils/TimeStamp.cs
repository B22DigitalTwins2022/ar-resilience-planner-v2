using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ShapeReality
{
    public static class TimeStamp
    {
        public const string ISO_8601_DATETIME_FORMAT = "yyyy-MM-ddTHH-mm-ss";

        public static string Now
        {
            get => DateTime.Now.ToString(ISO_8601_DATETIME_FORMAT);
        }
    }

}

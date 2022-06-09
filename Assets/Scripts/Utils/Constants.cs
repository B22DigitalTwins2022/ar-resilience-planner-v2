using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace ShapeReality.Constants
{
    public static class Scenes
    {
        public const string SCENENAME_MAIN = "Main";
        public const string SCENENAME_ENVIRONMENT = "Environment";
        public const string SCENENAME_CITY = "City";
        public const string SCENENAME_SIMULATION = "Simulation";
        public const string SCENENAME_SCENARIO_1 = "Scenario1";
        public const string SCENENAME_SCENARIO_2 = "Scenario2";
    }

    public static class Values
    {
        public const float CONTINUOUS_LOGGING_INTERVAL = 1f;
        public const float DEFAULT_FLY_SPEED = 0.05f;
    }

    public static class Paths
    {
        public const string USERSTUDY_DIRECTORYNAME = "UserStudy";

        public static readonly string rootPath = Application.persistentDataPath;
        public static readonly string userStudyPath = Path.Combine(rootPath, USERSTUDY_DIRECTORYNAME);
    }

    public static class Layers
    {
        private const string DEFAULT_LAYERMASK_STRING = "Default";
        private const string DRAGGING_OBJECT_LAYERMASK_STRING = "DraggingObject";

        public static readonly LayerMask @default = LayerMask.GetMask(DEFAULT_LAYERMASK_STRING);
        public static readonly LayerMask defaultIndex = LayerMask.NameToLayer(DEFAULT_LAYERMASK_STRING);
        public static readonly LayerMask dragging = LayerMask.GetMask(DRAGGING_OBJECT_LAYERMASK_STRING);
        public static readonly LayerMask draggingIndex = LayerMask.NameToLayer(DRAGGING_OBJECT_LAYERMASK_STRING);
    }
}


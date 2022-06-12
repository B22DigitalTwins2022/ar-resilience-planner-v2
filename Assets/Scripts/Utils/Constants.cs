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
        public const float DELTATIME_MULTIPLIER = 80f;

        public const float CONTINUOUS_LOGGING_INTERVAL = 1f;
        public const float DEFAULT_FLY_SPEED = 0.05f;
        public const float SMOOTH_TIME_FLYING = 0.03f;
        public const float SMOOTH_TIME_HOVER = 0.03f;
        public const float SMOOTH_TIME_PREVIEW_MODEL_TRANSFORM = 0.02f;

        public const float PLACING_SOLUTION_MODEL_DISTANCE = 0.4f;
        public const float PLACING_SOLUTION_MODEL_SCALE = 20f;
    }

    public static class Paths
    {
        public const string USERSTUDY_DIRECTORYNAME = "UserStudyV2";

        public static readonly string rootPath = Application.persistentDataPath;
        public static readonly string userStudyPath = Path.Combine(rootPath, USERSTUDY_DIRECTORYNAME);
    }

    public static class Layers
    {
        private const string DEFAULT_LAYERMASK_STRING = "Default";
        private const string DRAGGING_OBJECT_LAYERMASK_STRING = "DraggingObject";
        private const string SOLUTION_MODEL_LAYERMASK_STRING = "SolutionModel";

        public static readonly LayerMask @default = LayerMask.GetMask(DEFAULT_LAYERMASK_STRING);
        public static readonly LayerMask defaultIndex = LayerMask.NameToLayer(DEFAULT_LAYERMASK_STRING);
        public static readonly LayerMask dragging = LayerMask.GetMask(DRAGGING_OBJECT_LAYERMASK_STRING);
        public static readonly LayerMask draggingIndex = LayerMask.NameToLayer(DRAGGING_OBJECT_LAYERMASK_STRING);
        public static readonly LayerMask solutionModel = LayerMask.GetMask(SOLUTION_MODEL_LAYERMASK_STRING);
        public static readonly LayerMask solutionModelIndex = LayerMask.NameToLayer(SOLUTION_MODEL_LAYERMASK_STRING);
    }
}


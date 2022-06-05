using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality.Constants
{
    public static class Scenes
    {
        public const 
    }

    public static class Paths
    {
        public static readonly string playerSettings = Application.streamingAssetsPath + "/Player.json";
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


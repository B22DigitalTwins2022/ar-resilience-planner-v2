using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShapeReality
{
    /// <summary>
    /// Responsible for getting all solutions at start
    /// </summary>
    public class SolutionManager : MonoBehaviour
    {
        // Singleton behaviour
        private static SolutionManager _instance;
        public static SolutionManager Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
            }
        }

        [NonSerialized] public SolutionModel[] solutionModels;

        [NonSerialized] public List<SolutionModel> solutionModelsBuildingGreenCoverBalkony = new List<SolutionModel>();
        [NonSerialized] public List<SolutionModel> solutionModelsUrbanFarms = new List<SolutionModel>();
        [NonSerialized] public List<SolutionModel> solutionModelsGreenRoof = new List<SolutionModel>();
        [NonSerialized] public List<SolutionModel> solutionModelsPark = new List<SolutionModel>();
        [NonSerialized] public List<SolutionModel> solutionModelsGreenShadeSolution = new List<SolutionModel>();
        [NonSerialized] public List<SolutionModel> solutionModelsTrees = new List<SolutionModel>();
        [NonSerialized] public List<SolutionModel> solutionModelsWaterChannels = new List<SolutionModel>();

        public void Start()
        {
            solutionModels = FindObjectsOfType<SolutionModel>();

            AddSolutionsToModelLists(solutionModels);
        }

        private void AddSolutionsToModelLists(SolutionModel[] solutionModels)
        {
            foreach (SolutionModel solutionModel in solutionModels)
            {
                GetSolutionModelList(solutionModel.solutionType).Add(solutionModel);
                solutionModel.SetHoverVisualVisibility(false);
                solutionModel.SolutionIsActive = false;
            }
        }

        private ref List<SolutionModel> GetSolutionModelList(Solution.SolutionType solutionType)
        {
            switch (solutionType)
            {
                case Solution.SolutionType.BuildingGreenCoverBalkony:
                    return ref solutionModelsBuildingGreenCoverBalkony;
                case Solution.SolutionType.UrbanFarms:
                    return ref solutionModelsUrbanFarms;
                case Solution.SolutionType.GreenRoof:
                    return ref solutionModelsGreenRoof;
                case Solution.SolutionType.Park:
                    return ref solutionModelsPark;
                case Solution.SolutionType.GreenShadeSolution:
                    return ref solutionModelsGreenShadeSolution;
                case Solution.SolutionType.Trees:
                    return ref solutionModelsTrees;
                case Solution.SolutionType.WaterChannels:
                    return ref solutionModelsWaterChannels;
                default:
                    return ref solutionModelsBuildingGreenCoverBalkony;
            }
        }

        public void StartSolutionHover(Solution.SolutionType solutionType)
        {
            List<SolutionModel> solutionModelsToHover = GetSolutionModelList(solutionType);
            SetSolutionModelsHoverVisibility(solutionModelsToHover, true);
        }

        public void StopSolutionHover(Solution.SolutionType solutionType)
        {
            List<SolutionModel> solutionModelsToHover = GetSolutionModelList(solutionType);
            SetSolutionModelsHoverVisibility(solutionModelsToHover, false);
        }

        private void SetSolutionModelsHoverVisibility(List<SolutionModel> solutionModels, bool visibility)
        {
            foreach (SolutionModel solutionModel in solutionModels)
            {
                solutionModel.SetHoverVisualVisibility(visibility);
            }
        }

        public void ResetAllSolutionSlots()
        {
            if (solutionModels == null) { return; }
            foreach (SolutionModel solutionModel in solutionModels)
            {
                solutionModel.SolutionIsActive = false;
            }
            ClimateSimulation.Instance.UpdateSimulation();
        }
    }
}


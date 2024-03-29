﻿using Assets.Core;
using System.Collections.Generic;

namespace Assets.Farm
{
    public class BoxAreaFactory
    {
        private TrigerTimerService _trigerTimerService;
        private PlantConfigs _plantConfigs;
        private List<BoxPresenter> boxPresenters = new List<BoxPresenter>();

        public BoxAreaFactory(PlantConfigs plantConfigs,TrigerTimerService trigerTimerService)
        {
            _plantConfigs = plantConfigs;
            _trigerTimerService = trigerTimerService;
        }
        public BoxArea CreateBoxArea( LandingAreaView landingAreaView)// InProcess
        {

            boxPresenters = landingAreaView.boxPresenters;
            BoxModel[] boxModels = CreateBoxModels();

            for (int i = 0; i < boxPresenters.Count; i++)
            {
                boxModels[i].OnUpdateStatePlace += boxPresenters[i].Present;
            }

            var boxArea = new BoxArea(boxModels);

            return boxArea;
        } 

        private BoxModel[] CreateBoxModels()
        {
            BoxModel[] boxModels = new BoxModel[10];

            for(int i = 0; i < boxModels.Length; i++)
            {
                boxModels[i] = new BoxModel(_trigerTimerService, new UnityEngine.Vector3(0,0,0));
            }

            return boxModels;
        }
    }
}

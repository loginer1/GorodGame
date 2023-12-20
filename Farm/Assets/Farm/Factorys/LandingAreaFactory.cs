﻿using System;
using System.Collections.Generic;
using Assets.Core;
using Assets.Farm;

namespace Assets.Farm
{
    public class LandingAreaFactory
    {
        private StaticDataService _staticDataProvider;
        private PlantConfigs _plantConfigs;
        private GardenerService _gardenerService;

        public LandingAreaFactory(StaticDataService dataProvider, PlantConfigs plantConfigs, GardenerService gardenerService)
        {
            _staticDataProvider = dataProvider;
            _plantConfigs = plantConfigs;
            _gardenerService = gardenerService;
        }

        public LandingAreaModel CreateLandingArea()
        {
            var landingAreaModel = new LandingAreaModel();

            LandingAreaView landingAreaView = _staticDataProvider.GetData<LandingAreaView>();
            int placeCount = landingAreaView.GetPlaceCount();

            List<PlacePlanteModel> placePlanteModels = CreatePlacePlanteList(placeCount);
            List<PlacePlantePresenter> placePlantePresenters = landingAreaView.PlacePlantePresenters;

            landingAreaModel.Init(placePlanteModels, placePlantePresenters, _plantConfigs);

            return landingAreaModel;
        }

        private List<PlacePlanteModel> CreatePlacePlanteList(int count)
        {
            List<PlacePlanteModel> placePlanes = new List<PlacePlanteModel>();

            for(int i = 0; i < count; i++)
            {
                placePlanes.Add(new PlacePlanteModel(i, _gardenerService)); 
            }

            return placePlanes;
        }
    }
}

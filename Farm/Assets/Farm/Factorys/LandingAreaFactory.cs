using System;
using System.Collections.Generic;
using Assets.Core;
using Assets.Farm;

namespace Assets.Farm
{
    public class LandingAreaFactory
    {
        private DataProvider _dataProvider;
        private PlantConfigs _plantConfigs;

        public LandingAreaFactory(DataProvider dataProvider, PlantConfigs plantConfigs)
        {
            _dataProvider = dataProvider;
            _plantConfigs = plantConfigs;
        }

        public LandingAreaModel CreateLandingArea()
        {
            var landingAreaModel = new LandingAreaModel();

            LandingAreaView landingAreaView = _dataProvider.GetData<LandingAreaView>();
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
                placePlanes.Add(new PlacePlanteModel(_plantConfigs)); // TEmp ConfigArg
            }

            return placePlanes;
        }
    }
}

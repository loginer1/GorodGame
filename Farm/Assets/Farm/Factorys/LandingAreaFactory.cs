using System.Collections.Generic;
using Assets.Core;
using UnityEngine;

namespace Assets.Farm
{
    public class LandingAreaFactory
    {
        private StaticDataService _staticDataProvider;
        private PlantConfigs _plantConfigs;
      
        public LandingAreaFactory(StaticDataService dataProvider, PlantConfigs plantConfigs)
        {
            _staticDataProvider = dataProvider;
            _plantConfigs = plantConfigs;
        }

        public LandingAreaModel CreateLandingArea(GardenerService gardenerService, out LandingAreaView landingAreaView) { 
            var landingAreaModel = new LandingAreaModel();

             landingAreaView = _staticDataProvider.GetData<LandingAreaView>();
            int placeCount = landingAreaView.GetPlaceCount();

            Vector3[] placePositions = GetPlaceModelPosition(placeCount, landingAreaView);

            List<PlacePlanteModel> placePlanteModels = CreatePlacePlanteList(placeCount, placePositions, gardenerService);
            List<PlacePlantePresenter> placePlantePresenters = landingAreaView.PlacePlantePresenters;

            landingAreaModel.Init(placePlanteModels, placePlantePresenters, _plantConfigs);


            return landingAreaModel;
        }

        private List<PlacePlanteModel> CreatePlacePlanteList(int count, Vector3[] positions, GardenerService gardenerService)
        {
            List<PlacePlanteModel> placePlanes = new List<PlacePlanteModel>();

            for(int i = 0; i < count; i++)
            {
                placePlanes.Add(new PlacePlanteModel(i, gardenerService, positions[i])); 
            }

            return placePlanes;
        }

        private Vector3[] GetPlaceModelPosition(int placeCount, LandingAreaView landingAreaView)
        {
            Vector3[] list = new Vector3[placeCount];
            for (int i = 0; i < placeCount; i++)
                list[i] = landingAreaView.PlacePlantePresenters[i].transform.position;
            return list;
        }
    }
}

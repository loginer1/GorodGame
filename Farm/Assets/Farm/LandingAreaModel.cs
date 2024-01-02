using System;
using System.Collections.Generic;
using UnityEngine;
 
namespace Assets.Farm
{
    public class LandingAreaModel
    {
        private IReadOnlyList<PlacePlanteModel> _placePlanteModels = new List<PlacePlanteModel>();
        private IReadOnlyList<PlacePlantePresenter> _placePlantePresenters = new List<PlacePlantePresenter>();

        public void Init(List<PlacePlanteModel> placePlanteModels, List<PlacePlantePresenter> placePlantePresenters, PlantConfigs plantConfigs)
        {
            _placePlanteModels = placePlanteModels;
            _placePlantePresenters = placePlantePresenters;

            for(int i = 0; i < _placePlantePresenters.Count; i++)
            {
                _placePlantePresenters[i].Init(_placePlanteModels[i], plantConfigs);
                _placePlanteModels[i].OnChangePlanteModel += _placePlantePresenters[i].PresentSprite;
            }
        }

        public void OnDisable()
        {
            for (int i = 0; i < _placePlantePresenters.Count; i++)
            {
                _placePlanteModels[i].OnChangePlanteModel -= _placePlantePresenters[i].PresentSprite;
            }
        }

        public IReadOnlyList<IPlaceTask> GetPlaceTasks()
        {
            return _placePlanteModels;
        }
    }
}

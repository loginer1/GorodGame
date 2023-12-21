using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Persons;

namespace Assets.Farm
{
    public class GardenerService
    {
        private PlanteType _currentPlanteType;
        private Dictionary<PlanteType, Type> _plantForType;

        private List<IPlantModel> _plantModels = new List<IPlantModel>();
        private PlantPlaceTimer _waitTimer;

        private PlanteFactory _planteFactory;

        public GardenerService(PlanteFactory planteFactory)
        {
            _currentPlanteType = PlanteType.Kapusta;
            InitDictinory();

            _planteFactory = planteFactory;

        }

      

        public void StartTimerForPlanteInPlace(PlacePlanteModel placeModel)
        {
            StartTimer(1, () => PlanteInPlace(placeModel));
        }

        
        public void StartTimerForCollectPlanteInPlace(PlacePlanteModel planteModel, HeroModel heroModel)
        {
            StartTimer(1f, () => CollectPlanteInPlace(planteModel, heroModel));
        }
       
        
        public void Tick(float delta)
        {
            if (_waitTimer != null)
                _waitTimer.tick(delta);

            if (_plantModels.Count == 0)
                return;

            foreach(var i in _plantModels)
            {
                i.Grow(delta);
            }
        }
        
        private void PlanteInPlace(PlacePlanteModel placeModel)
        {
            var plante = _planteFactory.CreatePlanteForType(PlanteType.Kapusta);//Temp
            placeModel.Plante(plante);
            _plantModels.Add(plante);
            StopTimer();
        }

        private void CollectPlanteInPlace(PlacePlanteModel planteModel, HeroModel heroModel)
        {
            heroModel.Pudnyaty(planteModel.PlantType);
            Debug.Log("coll");
            planteModel.Collect();
            StopTimer();
        }

        private void StartTimer(float time, Action callback)
        {
            _waitTimer = new PlantPlaceTimer(time, callback);
        }
        private void StopTimer()
        {
            _waitTimer.Stop();
            _waitTimer = null;
        }

        private void InitDictinory()
        {
            _plantForType = new Dictionary<PlanteType, Type>();

            _plantForType.Add(PlanteType.Kapusta, typeof(KapustaModel));

        }

    }
    
}

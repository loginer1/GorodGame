using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Core;
using Assets.Persons;

namespace Assets.Farm
{
    public class GardenerService
    {
        private PlanteType _currentPlanteType;
        private Dictionary<PlanteType, Type> _plantForType;

        private List<IPlantModel> _plantModels = new List<IPlantModel>();

        private PlanteFactory _planteFactory;

        private TrigerTimerService _trigerTimerService;


        public GardenerService(PlanteFactory planteFactory, TrigerTimerService trigerTimerService)
        {
            _currentPlanteType = PlanteType.Carot;
            InitDictinory();

            _planteFactory = planteFactory;
            _trigerTimerService = trigerTimerService;

        }

        public void ExitTriger()
        {
            _trigerTimerService.ExitTriger();
        }

        public void JustEnterTriger()
        {
            _trigerTimerService.EnterTriger(0);
        }
        public void StartTimerForPlanteInPlace(PlacePlanteModel placeModel)
        {
            
            _trigerTimerService.EnterTriger(1, () => PlanteInPlace(placeModel));
        }

        
        public void StartTimerForCollectPlanteInPlace(PlacePlanteModel planteModel, HeroModel heroModel)
        {
          
            _trigerTimerService.EnterTriger(1, () => CollectPlanteInPlace(planteModel, heroModel));

        }
       
        
        public void Tick(float delta)
        {
            if (_plantModels.Count == 0)
                return;

            foreach(var i in _plantModels)
            {
                i.Grow(delta);
            }
        }
        
        private void PlanteInPlace(PlacePlanteModel placeModel)
        {
            var plante = _planteFactory.CreatePlanteForType(_currentPlanteType);
          
            placeModel.Plante(plante);
            _plantModels.Add(plante);
        }

        private void CollectPlanteInPlace(PlacePlanteModel planteModel, HeroModel heroModel)
        {
            heroModel.Pudnyaty(planteModel.PlantType);
            planteModel.Collect();
        }

       
      
       

        private void InitDictinory()
        {
            _plantForType = new Dictionary<PlanteType, Type>();

            _plantForType.Add(PlanteType.Kapusta, typeof(KapustaModel));
            _plantForType.Add(PlanteType.Carot, typeof(CarotModel));
        }

    }
    
}

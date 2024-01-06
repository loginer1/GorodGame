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
            Debug.Log(false);

            _trigerTimerService.EnterTriger(0, false);
        }
        public void StartTimerForPlanteInPlace(PlacePlanteModel placeModel,  bool isBot)
        {
        //    placeModel.TaskPerson.RemoveWorker();


            _trigerTimerService.EnterTriger(1 , isBot, () => PlanteInPlace(placeModel));
        }
        
        public void StartTimerForCollectPlanteInPlace(PlacePlanteModel placeModel, IPerson heroModel, bool isBot)
        {
        //    placeModel.TaskPerson.RemoveWorker();
          
            _trigerTimerService.EnterTriger(1, isBot, () => CollectPlanteInPlace(placeModel, heroModel));
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
        
        private void PlanteInPlace(IPlacePlanteModel placeModel)
        {
            var plante = _planteFactory.CreatePlanteForType(_currentPlanteType);
          
            placeModel.Plante(plante);
            _plantModels.Add(plante);
        }

        private void CollectPlanteInPlace(PlacePlanteModel planteModel, IPerson heroModel)
        {
     //       heroModel.Pudnyaty(planteModel.PlantType);
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

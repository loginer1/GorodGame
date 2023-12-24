using System;
using UnityEngine;
using Assets.Persons;

namespace Assets.Farm
{
    public class PlacePlanteModel
    {
        public event Action<int> OnChangePlanteModel;
        public PlanteType PlantType => _plantModel.PlanteType;
        public bool IsEmpty => _plantModel == null;
        public IPlantModel _plantModel { get; private set; }

        public int Id { get; }

        public float TimeLeftGrowing => !IsEmpty ? _plantModel.ProgressGrowing : 0;
      
        public int State { get; private set; }

        private GardenerService _gardenerService;


        
        public PlacePlanteModel(int id, GardenerService gardenerService) 
        {
            Id = id;
            _gardenerService = gardenerService;
            State = 0;
        }

        public void Plante(IPlantModel plantModel)
        {
            if (!IsEmpty)
                return;
            _plantModel = plantModel;
            State = 1;

            OnChangePlanteModel?.Invoke(1);

            _plantModel.OnGrewUp += OnGrewUp;
        }

       
        public void Collect()
        {
            if (IsEmpty)
                throw new InvalidOperationException();
            Debug.Log("sobraav  : " + _plantModel.PlanteType);

            _plantModel.OnGrewUp -= OnGrewUp;
            _plantModel = null;
            State = 0;
            OnChangePlanteModel?.Invoke(0);
            
        }

        public void EnterTriger(HeroModel heroModel)
        {
            if (State == 0)
                _gardenerService.StartTimerForPlanteInPlace(this);
            else if (State == 2)
                _gardenerService.StartTimerForCollectPlanteInPlace(this, heroModel);
            else if (State == 1)
                _gardenerService.JustEnterTriger();
        }       

        public void ExitTriger()
        {
            _gardenerService.ExitTriger();
        }
        private void OnGrewUp()
        {
            State = 2;
            OnChangePlanteModel?.Invoke(2);
        }

    }
}

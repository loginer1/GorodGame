using System;
using UnityEngine;

namespace Assets.Farm
{
    public class PlacePlanteModel
    {
        public event Action<int> OnChangePlanteModel;
        public PlanteType PlantType => _plantModel.PlanteType;
        public bool IsEmpty => _plantModel == null;
        public IPlantModel _plantModel { get; private set; }

        public int Id { get; }

        private GardenerService _gardenerService;
        
        public PlacePlanteModel(int id, GardenerService gardenerService) 
        {
            Id = id;
            _gardenerService = gardenerService;
        }

        public void Plante(IPlantModel plantModel)
        {
            if (!IsEmpty)
                return;

            _plantModel = plantModel;
            OnChangePlanteModel?.Invoke(1);

            _plantModel.OnGrewUp += OnGrewUp;
        }

        private void OnGrewUp()
        {
            OnChangePlanteModel?.Invoke(2);
        }

        public void Collect()
        {
            if (IsEmpty)
            {
                _plantModel.OnGrewUp -= OnGrewUp;
                _plantModel = null;
                OnChangePlanteModel?.Invoke(0);
            }
        }

        public void EnterTriger()
        {
               _gardenerService.EnterTrigerPlace(this);

        }

        public void SetCurrentTypePlante(PlanteType planteType)
        {

        }
    }
}

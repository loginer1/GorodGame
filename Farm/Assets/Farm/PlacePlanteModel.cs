using System;
using UnityEngine;

namespace Assets.Farm
{
    public class PlacePlanteModel
    {
        public event Action OnChangePlanteModel;
        public Type PlantType => _plantModel.GetType();
        public bool IsEmpty => _plantModel == null;
        public IPlantModel _plantModel { get; private set; }

        private PlantConfigs PlantConfigs; //TEEEMMMPPP
        
        public PlacePlanteModel(PlantConfigs plantConfigs) // TEEEMMPP
        {
            PlantConfigs = plantConfigs;
        }

        public void Plante(IPlantModel plantModel)
        {
            if (!IsEmpty)
                return;

            _plantModel = plantModel;
            OnChangePlanteModel?.Invoke();
        }

        public void Collect()
        {
            if (IsEmpty)
            {
                _plantModel = null;
                OnChangePlanteModel?.Invoke();
            }
        }

        public void EnterTriger()
        {
            var kapustaModel = new KapustaModel(PlantConfigs.GetCofigWithType(typeof(KapustaModel)));

            Plante(kapustaModel);

            Debug.Log(_plantModel);
        }
    }
}

using System;

namespace Assets.Farm
{
    public class PlacePlanteModel
    {
        public event Action<PlacePlanteModel> OnChangePlanteModel;
        public Type PlantType => _plantModel.GetType();
        public bool IsEmpty => _plantModel == null;
        public IPlantModel _plantModel { get; private set; }
        
        public void Plante(IPlantModel plantModel)
        {
            if (!IsEmpty)
                return;

            _plantModel = plantModel;
            OnChangePlanteModel?.Invoke(this);
        }

        public void Collect()
        {
            if (IsEmpty)
            {
                _plantModel = null;
                OnChangePlanteModel?.Invoke(this);
            }
        }

        public void EnterTriger()
        {
            OnChangePlanteModel?.Invoke(this);
        }
    }
}

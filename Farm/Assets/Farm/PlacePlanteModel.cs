using System;


namespace Assets.Farm
{
    public class PlacePlanteModel
    {
        public Type PlantType => _plantModel.GetType();
        private IPlantModel _plantModel;
        
        public void Plante(IPlantModel plantModel)
        {
            _plantModel = plantModel;
        }

        public void Collect()
        {

        }
    }
}

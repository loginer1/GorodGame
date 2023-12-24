using System;
using System.Collections.Generic;

namespace Assets.Farm
{
    public class PlanteFactory
    {
        private PlantConfigs _plantConfigs;

        public PlanteFactory(PlantConfigs plantConfigs)
        {
            _plantConfigs = plantConfigs;
        }

        public AbstractPlante CreatePlanteForType(PlanteType type)
        {
            AbstractPlante plante;
            switch (type)
            {
                case PlanteType.Kapusta:
                    plante = CreateKapusta(_plantConfigs.GetCofigWithType(PlanteType.Kapusta));
                    break;
                case PlanteType.Carot:
                    plante = CreateCarot(_plantConfigs.GetCofigWithType(PlanteType.Carot));
                    break;
                default:
                    throw new InvalidOperationException();
                    
            }
            return plante;
        }
        private KapustaModel CreateKapusta(IPlanteConfig planteConfig)
        {
            KapustaModel kapustaModel = new KapustaModel(planteConfig);
            return kapustaModel;
        }

        private CarotModel CreateCarot(IPlanteConfig planteConfig)
        {
            CarotModel carotModel = new CarotModel(planteConfig);
            return carotModel;
        }
    }
}

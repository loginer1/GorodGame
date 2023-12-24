using System;
using System.Collections.Generic;

namespace Assets.Farm
{
    public class CarotModel : AbstractPlante
    {
        public override PlanteType PlanteType => PlanteType.Carot;
        public CarotModel(IPlanteConfig planteConfig) : base(planteConfig) { }
    }
}

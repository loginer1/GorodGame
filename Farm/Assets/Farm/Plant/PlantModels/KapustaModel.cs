using System;
using System.Collections.Generic;

namespace Assets.Farm
{
    public class KapustaModel : AbstractPlante
    {
        public override PlanteType PlanteType => PlanteType.Kapusta;
        public KapustaModel(IPlanteConfig planteConfig) : base(planteConfig) { }

       
    }
}

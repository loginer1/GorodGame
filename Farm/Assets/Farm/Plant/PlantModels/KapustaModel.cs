using System;
using System.Collections.Generic;

namespace Assets.Farm
{
    public class KapustaModel : AbstractPlante
    {
        public override Type Type => GetType();
        public KapustaModel(IPlanteConfig planteConfig) : base(planteConfig) { }

       
    }
}

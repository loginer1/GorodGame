using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Farm
{
    public interface IReadOnlyPlacePlanteModel
    {
         event Action<int> OnChangePlanteModel;
         PlanteType PlantType { get; }
         bool IsEmpty { get; }

    }
}

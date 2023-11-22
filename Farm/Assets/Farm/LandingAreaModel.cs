using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Farm
{
    public class LandingAreaModel
    {
        private List<PlacePlanteModel> _placePlanteModels = new List<PlacePlanteModel>();
        private List<PlacePlantePresenter> _placePlantePresenters = new List<PlacePlantePresenter>();

        private void Init()
        {
            for(int i = 0; i < _placePlantePresenters.Count; i++)
            {
                _placePlanteModels[i].OnChangePlanteModel += _placePlantePresenters[i].Present;
            }
        }
    }
}

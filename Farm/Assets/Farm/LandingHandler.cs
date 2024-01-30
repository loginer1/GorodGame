using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Farm
{
    public class LandingHandler
    {
        public LandingAreaModel _landingAreaModel { get; }
        public BoxArea _boxArea { get; }
        public GardenerService _gardenerService { get; }

        public LandingHandler(LandingAreaModel landingAreaModel, BoxArea boxArea ,GardenerService gardenerService)
        {
            _landingAreaModel = landingAreaModel;
            _boxArea = boxArea;
            _gardenerService = gardenerService;
        }

        public void OnDisable()
        {
            _landingAreaModel.OnDisable();
            _boxArea.OnDisable();
        }
    }
}

using Assets.Core;

namespace Assets.Farm
{
    public class PlantingFieldFactory
    {
        private LandingAreaFactory _landingAreaFactory;
        private BoxAreaFactory _boxAreaFactory;
        private TrigerTimerService _trigerTimerService;
        private PlanteFactory _planteFactory;

        public PlantingFieldFactory(LandingAreaFactory landingAreaFactory, BoxAreaFactory boxAreaFactory , PlanteFactory planteFactory, TrigerTimerService trigerTimerService)
        {
            _landingAreaFactory = landingAreaFactory;
            _boxAreaFactory = boxAreaFactory;
            _trigerTimerService = trigerTimerService;
            _planteFactory = planteFactory;
        }

        public LandingHandler CreateLandingHandler()
        {
            GardenerService gardenerService = new GardenerService(_planteFactory, _trigerTimerService);
            LandingAreaModel landingAreaModel = _landingAreaFactory.CreateLandingArea(gardenerService, out LandingAreaView landingAreaView);
            BoxArea boxArea = _boxAreaFactory.CreateBoxArea(landingAreaModel, landingAreaView);
            gardenerService.Init(boxArea);

            LandingHandler landingHandler = new LandingHandler(landingAreaModel, boxArea, gardenerService);

            return landingHandler;
        }
    }
}

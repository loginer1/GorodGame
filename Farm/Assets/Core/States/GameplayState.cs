using Assets.Persons;
using Assets.Farm;

namespace Assets.Core
{
    public class GameplayState : IGameState
    {
        private HeroHandler _heroHandler;
        private ServiceLocator _serviceLocator;
        private StateMachinGame _stateMachin;
        private StaticDataService _staticDataProvider;
        private LandingHandler _landingHandler;
        private TrigerTimerService _trigerTimerService;
        private TaskPersonService _taskPersonService;

        private BotModel botModel;  // TEMP
        private BotModel botModel2; // TEMP
        private BotModel botModel3; // TEMP

        public GameplayState(ServiceLocator DI, StateMachinGame stateMachin)
        {
            _serviceLocator = DI;
            _stateMachin = stateMachin;
        }

        public void Enter()
        {
            _staticDataProvider = _serviceLocator.Resolve<StaticDataService>();
            var personsFactory =  _serviceLocator.Resolve<PersonsFactory>();
            var plantingFieldFactory = _serviceLocator.Resolve<PlantingFieldFactory>();
            _trigerTimerService = _serviceLocator.Resolve<TrigerTimerService>();
            _taskPersonService = _serviceLocator.Resolve<TaskPersonService>();


            _landingHandler = plantingFieldFactory.CreateLandingHandler();

        
            _heroHandler = personsFactory.CreateHero();
            _taskPersonService.Init(_landingHandler._landingAreaModel);


            botModel = new BotModel(_taskPersonService);// TEMP{
            var botPresenter = _staticDataProvider.GetData<BotPresenter>();

            botModel2 = new BotModel(_taskPersonService);
            var botPresenter2 = _staticDataProvider.GetData<BotPresenter>();

            botModel3 = new BotModel(_taskPersonService);
            var botPresenter3 = _staticDataProvider.GetData<BotPresenter>();

            botPresenter.Init(botModel);
            botPresenter2.Init(botModel2);
            botPresenter3.Init(botModel3);// TEMP }

        }

        public void Exit()
        {
            _heroHandler.OnDisable();
            _landingHandler.OnDisable();
            _taskPersonService.OnDisable();
        }

        public void Update(float delta)
        {
            _heroHandler.Tick(delta);
            _landingHandler._gardenerService.Tick(delta);
            _trigerTimerService.Tick(delta);
            botModel.Tick(delta);
            botModel2.Tick(delta);
            botModel3.Tick(delta);
        }
    }
}

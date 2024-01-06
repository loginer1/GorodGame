using System;
using UnityEngine;
using Assets.Persons;
using Assets.Farm;

namespace Assets.Core
{
    public class GameplayState : IGameState
    {
        private HeroHandler _heroHandler;
        private DiContainer _diContainer;
        private StateMachinGame _stateMachin;
        private StaticDataService _staticDataProvider;
        private GardenerService _gardenerService;
        private LandingAreaModel _landingArea;
        private TrigerTimerService _trigerTimerService;
        private TaskPersonService _taskPersonService;

        private bool bylo = false;
        BotModel botModel;
        BotModel botModel2;
        BotModel botModel3;

        public GameplayState(DiContainer DI, StateMachinGame stateMachin)
        {
            _diContainer = DI;
            _stateMachin = stateMachin;
           
        }

        public void Enter()
        {
            _staticDataProvider = _diContainer.Resolve<StaticDataService>();
            var personsFactory =  _diContainer.Resolve<PersonsFactory>();
            var landingAreaFactory = _diContainer.Resolve<LandingAreaFactory>();
            _trigerTimerService = _diContainer.Resolve<TrigerTimerService>();
            _gardenerService = _diContainer.Resolve<GardenerService>();
            _taskPersonService = _diContainer.Resolve<TaskPersonService>();
            _landingArea = landingAreaFactory.CreateLandingArea();
        
            _heroHandler = personsFactory.CreateHero();
            _taskPersonService.Init(_landingArea);


            botModel = new BotModel(_taskPersonService);
            var botPresenter = _staticDataProvider.GetData<BotPresenter>();

            botModel2 = new BotModel(_taskPersonService);
            var botPresenter2 = _staticDataProvider.GetData<BotPresenter>();

            botModel3 = new BotModel(_taskPersonService);
            var botPresenter3 = _staticDataProvider.GetData<BotPresenter>();

            botPresenter.Init(botModel);
            botPresenter2.Init(botModel2);
            botPresenter3.Init(botModel3);

        }

        public void Exit()
        {
            _heroHandler.OnDisable();
            _landingArea.OnDisable();
            _taskPersonService.OnDisable();
        }

        public void Update(float delta)
        {
            _heroHandler.Tick(delta);
            _gardenerService.Tick(delta);
            _trigerTimerService.Tick(delta);
            botModel.Tick(delta);
            botModel2.Tick(delta);
            botModel3.Tick(delta);
        }
    }
}

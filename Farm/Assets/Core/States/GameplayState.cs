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
            _gardenerService = _diContainer.Resolve<GardenerService>();

            var landingArea = landingAreaFactory.CreateLandingArea();
            
            _heroHandler = personsFactory.CreateHero();

     
            
        }

        public void Exit()
        {
        }

        public void Update(float delta)
        {
            _heroHandler.Tick(delta);
            _gardenerService.Tick(delta);
        }
    }
}

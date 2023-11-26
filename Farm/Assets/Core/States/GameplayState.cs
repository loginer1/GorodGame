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
        private DataProvider _dataProvider;

        public GameplayState(DiContainer DI, StateMachinGame stateMachin)
        {
            _diContainer = DI;
            _stateMachin = stateMachin;
           
        }

        public void Enter()
        {
            _dataProvider = _diContainer.Resolve<DataProvider>();
            var personsFactory =  _diContainer.Resolve<PersonsFactory>();
            var landingAreaFactory = new LandingAreaFactory(_dataProvider);

            var landingArea = landingAreaFactory.CreateLandingArea();
            
            _heroHandler = personsFactory.CreateHero();
        }

        public void Exit()
        {
        }

        public void Update(float delta)
        {
            _heroHandler.Tick(delta);
        }
    }
}

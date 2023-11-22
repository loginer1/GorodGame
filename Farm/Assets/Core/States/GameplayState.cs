using System;
using UnityEngine;
using Assets.Persons;

namespace Assets.Core
{
    public class GameplayState : IGameState
    {
        private HeroHandler _heroHandler;
        private DiContainer _diContainer;
        private StateMachinGame _stateMachin;

        public GameplayState(DiContainer DI, StateMachinGame stateMachin)
        {
            _diContainer = DI;
            _stateMachin = stateMachin;
           
        }

        public void Enter()
        {
            var personsFactory =  _diContainer.Resolve<PersonsFactory>();


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

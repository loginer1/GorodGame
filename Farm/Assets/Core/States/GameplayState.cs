using System;
using UnityEngine;
using Assets.Persons;

namespace Assets.Core
{
    public class GameplayState : IGameState
    {
        private PersonsConfig _personsConfig;
        private HeroModel _heroModel;
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
            _personsConfig = _diContainer.Resolve<PersonsConfig>();
            _heroModel = _diContainer.Resolve<HeroModel>();
            _heroHandler = _diContainer.Resolve<HeroHandler>();

            var heroPresenter = UnityEngine.Object.Instantiate(_personsConfig.HeroPrefab).GetComponent<HeroPresenter>();

            _heroHandler.SetPresenter(heroPresenter);
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

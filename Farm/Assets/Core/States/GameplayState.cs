using System;
using UnityEngine;
using Assets.Persons;

namespace Assets.Core
{
    public class GameplayState : IGameState
    {
        private PersonsConfig _personsConfig;
        public GameplayState(PersonsConfig personsConfig)
        {
            _personsConfig = personsConfig;
        }
        public void Enter()
        {
            var heroPresenter = UnityEngine.Object.Instantiate(_personsConfig.HeroPrefab).GetComponent<HeroPresenter>();;

            heroPresenter.Init(new HeroModel());
        }

        public void Exit()
        {
        }

        public void Update(float delta)
        {
        }
    }
}

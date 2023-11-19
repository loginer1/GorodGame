using System;
using Assets.Persons;

namespace Assets.Core
{
    public class BootstrapState : IGameState
    {   
        private StateMachinGame _stateMachin;
        private DiContainer _diContainer;

        public BootstrapState( DiContainer DI, StateMachinGame stateMachin)
        {
            _diContainer = DI;
            _stateMachin = stateMachin;
        }
        public void Enter()
        {
            var sceneLoader = new SceneLoader();
            var serializator = new Serializator();

            var assetProvider = new AssetProvider();
            var dataProvider = new DataProvider(assetProvider);

            var heroModel = new HeroModel();

            var personsConfig = _diContainer.Resolve<PersonsConfig>();
            var personsFactory = new PersonsPresenterFactory(personsConfig);

            _diContainer.Register(sceneLoader);
            _diContainer.Register(serializator);
            _diContainer.Register(assetProvider);
            _diContainer.Register(dataProvider);

            _diContainer.Register(heroModel);
            _diContainer.Register(personsFactory);

            sceneLoader.LoadScnene("GameplayScene", () => _stateMachin.ChangeState<GameplayState>());
        }

        public void Exit()
        {
        }

        public void Update(float delta)
        {
        }
    }

}

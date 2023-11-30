using System;
using Assets.Persons;
using Assets.Farm;

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

            var plantConfigs = _diContainer.Resolve<PlantConfigs>();
            var landingAreaModel = new LandingAreaFactory(dataProvider, plantConfigs);

            var personsConfig = _diContainer.Resolve<PersonsConfig>();
            var personsFactory = new PersonsFactory(personsConfig, dataProvider);

            _diContainer.Register(sceneLoader);
            _diContainer.Register(serializator);
            _diContainer.Register(assetProvider);
            _diContainer.Register(dataProvider);

            _diContainer.Register(landingAreaModel);

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

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
            var staticDataProvider = new StaticDataService(assetProvider);

            var trigerTimerSerice = new TrigerTimerService();
           
            var plantConfigs = _diContainer.Resolve<PlantConfigs>(); 
            var planteFactory = new PlanteFactory(plantConfigs);

            var boxFactory = new BoxAreaFactory(plantConfigs, trigerTimerSerice);
            var landingAreaModel = new LandingAreaFactory(staticDataProvider, plantConfigs);
            var plantingFieldFactory = new PlantingFieldFactory(landingAreaModel, boxFactory, planteFactory, trigerTimerSerice);

            var personsConfig = _diContainer.Resolve<PersonsConfig>();
            var personsFactory = new PersonsFactory(personsConfig, staticDataProvider);

            var taskPersonFactory = new TaskPersonFactory();
            var taskPersonService = new TaskPersonService(taskPersonFactory);

            _diContainer.Register(sceneLoader);
            _diContainer.Register(serializator);
            _diContainer.Register(assetProvider);
            _diContainer.Register(staticDataProvider);

            _diContainer.Register(trigerTimerSerice);

            _diContainer.Register(landingAreaModel);
            _diContainer.Register(plantingFieldFactory);

            _diContainer.Register(personsFactory);
            _diContainer.Register(taskPersonService);

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

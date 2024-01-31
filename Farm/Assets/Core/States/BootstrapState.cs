using Assets.Persons;
using Assets.Farm;

namespace Assets.Core
{
    public class BootstrapState : IGameState
    {   
        private StateMachinGame _stateMachin;
        private ServiceLocator _serviceLocator;

        public BootstrapState( ServiceLocator serviceLocator, StateMachinGame stateMachin)
        {
            _serviceLocator = serviceLocator;
            _stateMachin = stateMachin;
        }
        public void Enter()
        {
            var sceneLoader = new SceneLoader();
            var serializator = new Serializator();

            var assetProvider = new AssetProvider();
            var staticDataProvider = new StaticDataService(assetProvider);

            var trigerTimerSerice = new TrigerTimerService();
           
            var plantConfigs = _serviceLocator.Resolve<PlantConfigs>(); 
            var planteFactory = new PlanteFactory(plantConfigs);

            var boxFactory = new BoxAreaFactory(plantConfigs, trigerTimerSerice);
            var landingAreaModel = new LandingAreaFactory(staticDataProvider, plantConfigs);
            var plantingFieldFactory = new PlantingFieldFactory(landingAreaModel, boxFactory, planteFactory, trigerTimerSerice);

            var personsConfig = _serviceLocator.Resolve<PersonsConfig>();
            var personsFactory = new PersonsFactory(personsConfig, staticDataProvider);

            var taskPersonFactory = new TaskPersonFactory();
            var taskPersonService = new TaskPersonService(taskPersonFactory);

            _serviceLocator.Register(sceneLoader);
            _serviceLocator.Register(serializator);
            _serviceLocator.Register(assetProvider);
            _serviceLocator.Register(staticDataProvider);

            _serviceLocator.Register(trigerTimerSerice);

            _serviceLocator.Register(landingAreaModel);
            _serviceLocator.Register(plantingFieldFactory);

            _serviceLocator.Register(personsFactory);
            _serviceLocator.Register(taskPersonService);

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

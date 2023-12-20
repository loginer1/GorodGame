using Assets.Core;

namespace Assets.Persons
{
    public class PersonsFactory
    {
        private PersonsConfig _personsConfig;
        private StaticDataService _dataProvider;

        public PersonsFactory(PersonsConfig personsConfig, StaticDataService dataProvider)
        {
            _personsConfig = personsConfig;
            _dataProvider = dataProvider;
        }

        public HeroHandler CreateHero()
        {
            var heroModel = new HeroModel();
            var heroPresenter = UnityEngine.Object.Instantiate(_personsConfig.HeroPrefab).GetComponent<HeroPresenter>();
            var heroHandler = new HeroHandler(heroModel, _personsConfig.Speed);
            heroHandler.SetPresenter(heroPresenter);

            var camera = _dataProvider.GetData<HeroCamera>();
            camera.Init(heroPresenter.transform);

            return heroHandler;
        }
    }
}

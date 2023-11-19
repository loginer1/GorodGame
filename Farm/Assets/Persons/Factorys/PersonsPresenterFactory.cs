using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Persons
{
    public class PersonsPresenterFactory
    {
        private PersonsConfig _personsConfig;

        public PersonsPresenterFactory(PersonsConfig personsConfig)
        {
            _personsConfig = personsConfig;
        }

        public HeroHandler CreateHero(HeroModel heroModel)
        {
            var heroPresenter = UnityEngine.Object.Instantiate(_personsConfig.HeroPrefab).GetComponent<HeroPresenter>();
            var heroHandler = new HeroHandler(heroModel);
            heroHandler.SetPresenter(heroPresenter);

            return heroHandler;
        }
    }
}

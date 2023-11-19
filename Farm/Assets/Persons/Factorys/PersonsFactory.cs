using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Persons
{
    public class PersonsFactory
    {
        private PersonsConfig _personsConfig;

        public PersonsFactory(PersonsConfig personsConfig)
        {
            _personsConfig = personsConfig;
        }

        public HeroHandler CreateHero()
        {
            var heroModel = new HeroModel();
            var heroPresenter = UnityEngine.Object.Instantiate(_personsConfig.HeroPrefab).GetComponent<HeroPresenter>();
            var heroHandler = new HeroHandler(heroModel);
            heroHandler.SetPresenter(heroPresenter);

            return heroHandler;
        }
    }
}

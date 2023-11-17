using UnityEngine;

namespace Assets.Persons 
{
    public class HeroPresenter : MonoBehaviour
    {
        private HeroModel _heroModel;

        public void Init(HeroModel heroModel)
        {
            _heroModel = heroModel;
        }

        public void PresentPosition()
        {
            transform.position = _heroModel._position;
        }
    } 
}

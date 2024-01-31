using UnityEngine;
using Assets.Farm;

namespace Assets.Persons 
{
    public class HeroPresenter : MonoBehaviour
    {
        public HeroModel _heroModel { get; private set; }

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

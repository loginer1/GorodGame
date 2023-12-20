using UnityEngine;
using Assets.Farm;

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

      /*  private void OnTriggerEnter2D(Collider2D collision)
        {
            if( collision.gameObject.TryGetComponent(out PlacePlantePresenter placePlantePresenter))
            {
                _heroModel.EnterTriger(placePlantePresenter);
            }
        }*/
    } 
}

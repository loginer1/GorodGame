using UnityEngine;
using System;
using Assets.Farm;

namespace Assets.Persons
{
    public class HeroModel : IMovable
    {
        public Vector2 _position { get; private set; }
        public event Action ChangePosition;

        private bool _isCarrying;
        

        public HeroModel()
        {
            _position = new Vector2(3, 2);
        }
        public void Move(Vector2 newPosition)
        {
            _position = newPosition; 

            ChangePosition?.Invoke();
        }

        public void Pudnyaty(PlanteType planteType)
        {
            Debug.Log(planteType);
          //  if(collision is PlacePlantePresenter)
          //      (PlacePlantePresenter)collision.

        }

    }
}

using UnityEngine;
using System;

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


    }
}

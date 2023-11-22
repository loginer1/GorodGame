using UnityEngine;
using System;

namespace Assets.Persons
{
    public class HeroMoving
    {
        private IMovable _hero;
        private float _speed = 5; // get in hero info

        public HeroMoving(IMovable hero)
        {
            _hero = hero;         
        }

        public void SetSpeed(float speed)
        {
            if (speed < 0)
                throw new ArgumentOutOfRangeException();

            _speed = speed;
        }

        public void Tick(float delta)
        {
            var newPosition = _hero._position;

            if (Input.GetKey(KeyCode.W))
                newPosition.y += _speed * delta;
            if (Input.GetKey(KeyCode.A))
                newPosition.x -= _speed * delta;
            if (Input.GetKey(KeyCode.S))
                newPosition.y -= _speed * delta;
            if (Input.GetKey(KeyCode.D))
                newPosition.x += _speed * delta;

            _hero.Move(newPosition);
        }
    }
}

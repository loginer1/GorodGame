using UnityEngine;

namespace Assets.Persons
{
    public class HeroMoving
    {
        private IMovable _hero;
        private float speed = 5; // get in hero info

        public HeroMoving(IMovable hero)
        {
            _hero = hero;
        }

        public void Tick(float delta)
        {
            var newPosition = _hero._position;

            if (Input.GetKey(KeyCode.W))
                newPosition.y += speed;
            if (Input.GetKey(KeyCode.A))
                newPosition.x -= speed;
            if (Input.GetKey(KeyCode.S))
                newPosition.y -= speed;
            if (Input.GetKey(KeyCode.D))
                newPosition.x += speed;

            _hero.Move(newPosition * delta);
        }
    }
}

using System;
using UnityEngine;

namespace Assets.Persons
{
    public interface IMovable
    {
        Vector2 _position { get; }
        void Move(Vector2 newPosition);
    }
}

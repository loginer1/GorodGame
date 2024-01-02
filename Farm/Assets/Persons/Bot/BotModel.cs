using Assets.Farm;
using System;
using UnityEngine;

namespace Assets.Persons
{
    public class BotModel : IPerson, IMovable
    {
        public event Action ChangePosition;

        public Vector2 _position { get; private set; }
        private float _speed = 2;

        public ITaskPerson Task = null;

        private BotStateMachin _stateMachin;
        private TaskPersonService _taskPersonService;

        public BotModel(TaskPersonService taskPersonService)
        {
            _position = new Vector2(10, 10);
            _taskPersonService = taskPersonService;
            _stateMachin = new BotStateMachin(_taskPersonService, this, Task);
        }

        public void Move(Vector2 newPosition)
        {
            _position = Vector2.MoveTowards(_position, newPosition, _speed * Time.deltaTime);
            ChangePosition?.Invoke();
        }

        public void Pudnyaty(PlanteType planteType)
        {
            
        }

        public void Tick(float delta)
        {
            _stateMachin.Tick(delta);
        }
    }
}

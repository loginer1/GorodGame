using System;
using UnityEngine;

namespace Assets.Persons
{
    public class MoveToTaskState : IBotState
    {
        private BotStateMachin _botStateMachin;
        private BotModel _botModel;
        private ITaskPerson _taskPerson;
        private Vector2 _taskPositon;

        public MoveToTaskState(BotStateMachin botStateMachin,  BotModel botModel )
        {
            _botStateMachin = botStateMachin;
            _botModel = botModel;
        }
        public void Enter()
        {
            _taskPerson = _botModel.Task;
            _taskPositon = _taskPerson.Position;
            _taskPerson.ChangeWorker += FindNewTask;
        }

        public void Exit()
        {
            _taskPerson.ChangeWorker -= FindNewTask;
        }

        private void FindNewTask()
        {
            _botStateMachin.ChangeState(BotStates.FindTask);
        }

        public void Update(float delta)
        {
            _botModel.Move(_taskPositon);
            if (_botModel._position == _taskPositon)
                _botStateMachin.ChangeState(BotStates.Execute);
        }
    }
}

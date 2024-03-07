using System;
using UnityEngine;

namespace Assets.Persons
{
    public class ExecuteState : IBotState
    {
        private BotStateMachin _botStateMachin;
        private BotModel _botModel;

        private ITaskPerson _taskPerson;

        public ExecuteState(BotStateMachin botStateMachin, BotModel botModel)
        {
            _botStateMachin = botStateMachin;
            _botModel = botModel;
            
        }

        public void Enter()
        {
            _taskPerson = _botModel.Task;
            _taskPerson.Execute();
          //  Debug.Log("exe");
            _taskPerson.OnReady += ChangeState;
        }

        public void Exit()
        {
           _taskPerson.OnReady -= ChangeState;
        }

        public void Update(float delta)
        {
        }

        private void ChangeState()
        {
            _botModel.Task = null;
            _botStateMachin.ChangeState(BotStates.FindTask);
        }
    }
}

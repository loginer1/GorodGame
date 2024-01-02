using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Persons
{
    public class BotStateMachin
    {
        private Dictionary<BotStates, IBotState> _states;
        private IBotState _currentState;
        private TaskPersonService _taskPersonService;
        private BotModel _botModel;
        private ITaskPerson _taskPerson;

        public BotStateMachin( TaskPersonService taskPersonService, BotModel botModel, ITaskPerson taskPerson)
        {
            _states = new Dictionary<BotStates, IBotState>();
            _taskPersonService = taskPersonService;
            _botModel = botModel;
            _taskPerson = taskPerson;

            Init();
        }

        public void ChangeState(BotStates botStates)
        {
            _currentState?.Exit();
            _currentState = _states[botStates];
            _currentState.Enter();
        }

        private void Init()
        {
            var FindTaskState = new FindTaskState(this, _taskPersonService, _botModel);
            var MoveToTaskState = new MoveToTaskState(this, _botModel);
            var ExecuteState = new ExecuteState(this, _botModel);

            _states.Add(BotStates.FindTask, FindTaskState);
            _states.Add(BotStates.MoveToTask, MoveToTaskState);
            _states.Add(BotStates.Execute, ExecuteState);

            ChangeState(BotStates.FindTask);
        }
        public void Tick(float delta)
        {
            _currentState.Update(delta);
        }
    }
}

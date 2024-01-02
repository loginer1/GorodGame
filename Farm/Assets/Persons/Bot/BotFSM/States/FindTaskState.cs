using System;
using UnityEngine;

namespace Assets.Persons
{
    public class FindTaskState : IBotState
    {
        private BotStateMachin _botStateMachin;
        private TaskPersonService _taskPersonService;
        private BotModel _botModel;

        public FindTaskState(BotStateMachin botStateMachin, TaskPersonService taskPersonService, BotModel botModel)
        {
            _botStateMachin = botStateMachin;
            _taskPersonService = taskPersonService;
            _botModel = botModel;
        }
        public void Enter()
        {         
            _botModel.Task = _taskPersonService.GetClosestTaskToMe(_botModel);
     
            _botStateMachin.ChangeState(BotStates.MoveToTask);
        }

        public void Exit()
        {
        }

        public void Update(float delta)
        {

        }
    }
}

using System;
using UnityEngine;
using Assets.Farm;

namespace Assets.Persons
{
    public class FindTaskState : IBotState
    {
        private BotStateMachin _botStateMachin;
        private TaskPersonService _taskPersonService;
        private BotModel _botModel;

        private bool taskType = false;

        public FindTaskState(BotStateMachin botStateMachin, TaskPersonService taskPersonService, BotModel botModel)
        {
            _botStateMachin = botStateMachin;
            _taskPersonService = taskPersonService;
            _botModel = botModel;
        }
        public void Enter()
        {
            ITaskPerson taskPerson;
            if (taskType == false)
            {
                taskPerson = _taskPersonService.GetClosestTaskToMe(_botModel, TaskTypes.plante);
                if(taskPerson == null)
                {
                    taskPerson = _taskPersonService.GetClosestTaskToMe(_botModel, TaskTypes.collect);
                    taskType = true;
                }

            }
            else 
            {
                taskPerson = _taskPersonService.GetClosestTaskToMe(_botModel, TaskTypes.collect);
                if (taskPerson == null)
                {
                    taskPerson = _taskPersonService.GetClosestTaskToMe(_botModel, TaskTypes.plante);
                    taskType = false;
                }

            }

            _botModel.Task = taskPerson;

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

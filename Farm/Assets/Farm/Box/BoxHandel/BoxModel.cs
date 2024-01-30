using Assets.Persons;
using System;

using UnityEngine;
using Assets.Core;


namespace Assets.Farm
{
    public class BoxModel : IPlaceTask
    {       
        public event Action<TaskTypes, IPlaceTask> OnUpdateStatePlace;

        public ITaskPerson TaskPerson { get; private set; }

        public Vector3 Position { get; }

        public TaskTypes TaskType { get; private set; }

        public bool WhosWorkingNow { get; private set; }
        public PlanteType PlanteType { get; private set; }

        private TrigerTimerService _trigerTimerService;
        private bool pudnyato = false;

        private bool IsActive = false;



        public BoxModel(TrigerTimerService trigerTimerService )
        {
            _trigerTimerService = trigerTimerService;
        }

        public void Execute(IPerson Who)
        {
            bool isBot = false;
            if (Who is BotModel)
                isBot = true;


            if (TaskPerson != null && TaskPerson.InProcess && isBot == false)
            {
                _trigerTimerService.EnterTriger(0, false);
                return;
            }

            if (pudnyato == false)
                Pudnyaty(Who);
            else
                Poklasty();
        }

        private void Pudnyaty(IPerson person)
        {
            person.Pudnyaty(PlanteType);
            pudnyato = true;

            OnUpdateStatePlace?.Invoke(TaskTypes.none, this);
        }

        private void Poklasty()
        {
            pudnyato = false;
            OnUpdateStatePlace?.Invoke(TaskTypes.plante, this);
            RemoveTask();
        }

        public void RemoveTask()
        {
            TaskPerson = null;
        }

        public void SetTask(ITaskPerson taskPerson)
        {
            TaskPerson = taskPerson;
        }

        public void SetActive(bool isActive, PlanteType planteType)
        {
            IsActive = isActive;
            PlanteType = planteType;
            Debug.Log(isActive);
            OnUpdateStatePlace?.Invoke(TaskTypes.collect, this);
        }
    }
}

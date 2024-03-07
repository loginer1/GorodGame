using Assets.Persons;
using System;
using UnityEngine;

namespace Assets.Farm
{
    public abstract class PlaceTask : IPlaceTask
    {       
        public event Action<TaskTypes, IPlaceTask> OnUpdateStatePlace;

        public ITaskPerson TaskPerson { get; private set; }

        public Vector3 Position { get; }

        public TaskTypes TaskType { get; protected set; }

        public bool WhosWorkingNow { get; protected set; }

        public PlaceTask(Vector3 position)
        {
            Position = position;
        }

        public void Execute(IPerson Who)
        {
            bool isBot = false;
            if (Who is BotModel)
                isBot = true;


            if (TaskPerson != null && TaskPerson.InProcess && isBot == false)
            {
                EnterTrigerTaskInProces();
                return;
            }
            TaskPerson.SetWorker(Who);

            MyExecute(isBot, Who);
        }

        public void RemoveTask()
        {
            TaskPerson = null;
        }

        public void SetTask(ITaskPerson taskPerson)
        {
            TaskPerson = taskPerson;
        }

        protected abstract void EnterTrigerTaskInProces();
        protected abstract void MyExecute(bool IsBot, IPerson Who);
        protected void InvokeUptadePlaceState(TaskTypes taskTypes, IPlaceTask placeTask)
        {
            OnUpdateStatePlace?.Invoke(taskTypes, placeTask);
        }
    }
}

using Assets.Farm;
using System;
using UnityEngine;

namespace Assets.Persons
{
    public class TaskBot : ITaskPerson
    {
        public event Action ChangeWorker;

        public event Action OnReady;

        public bool InProcess { get; private set; }

        public Vector3 Position { get; }

        public IPerson Person { get; private set; }

        public bool Zanatiy => Person != null;

        public TaskTypes TaskType { get; }

        public IPlaceTask PlaceTask { get; private set; }

        public TaskBot(Vector3 position, IPlaceTask placeTask)
        {
            Position = position;
            PlaceTask = placeTask;
            TaskType = PlaceTask.TaskType;
        }

        public void Execute()
        {
            PlaceTask.Execute(Person);
            PlaceTask.OnUpdateStatePlace += IsReady;
            InProcess = true;
        }

        public void RemoveWorker()
        {
            Person = null;
            ChangeWorker?.Invoke();
        }

        public void SetWorker(IPerson Who)
        {
            Person = Who;
            ChangeWorker?.Invoke();
        }
        private void IsReady(TaskTypes taskTypes, IPlaceTask placeTask)
        {
            PlaceTask.OnUpdateStatePlace -= IsReady;
            OnReady?.Invoke();
            RemoveWorker();
            InProcess = false;

        }
    }
}

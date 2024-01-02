using Assets.Farm;
using System;
using UnityEngine;

namespace Assets.Persons
{
    public class CollectTask : ITaskPerson
    {       
        public event Action ChangeWorker;

        public event Action OnReady;
        public Vector3 Position { get; }

        public bool InProcess { get; private set; }

        public IPlaceTask PlaceTask { get; private set; }

        public IPerson Person { get; private set; }

        public CollectTask(Vector3 position, IPlaceTask placeTask)
        {
            Position = position;
            PlaceTask = placeTask;
        }

        public void Execute()
        {
            PlaceTask.Execute(Person);
            PlaceTask.OnUpdateStatePlace += IsReady;
        }

        public void RemoveWorker()
        {
            Person = null;

        }

        public void SetWorker(IPerson person)
        {
            Person = person;
            ChangeWorker?.Invoke();
            Person = null;
        }

        private void IsReady(TaskTypes taskTypes, IPlaceTask placeTask)
        {
            PlaceTask.OnUpdateStatePlace -= IsReady;
            OnReady?.Invoke();
        }

    }
}

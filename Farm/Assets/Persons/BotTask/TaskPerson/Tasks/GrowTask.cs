﻿using System;
using UnityEngine;
using Assets.Farm;

namespace Assets.Persons
{
    public class GrowTask : ITaskPerson
    {
        public event Action ChangeWorker;

        public event Action OnReady;

        public bool InProcess { get; private set; }

        public Vector3 Position { get; }

        public IPerson Person { get; private set; }

        public IPlaceTask PlaceTask { get; private set; }

        public TaskTypes TaskType => throw new NotImplementedException();

        public bool Zanatiy => throw new NotImplementedException();

        public GrowTask(Vector3 position, IPlaceTask placeTask)
        {
            Position = position;
            PlaceTask = placeTask;
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

        private void IsReady(TaskTypes taskTypes, IPlaceTask placeTask)
        {
            PlaceTask.OnUpdateStatePlace -= IsReady;
            OnReady?.Invoke();
            InProcess = false;
        }

        public void SetWorker(IPerson person)
        {
            Person = person;
            ChangeWorker?.Invoke();
        }

        
    }
}

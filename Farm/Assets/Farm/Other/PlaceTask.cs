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

        public TaskTypes TaskType { get; private set; }

        public bool WhosWorkingNow { get; private set; }


        public void Execute(IPerson Who)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask()
        {
            throw new NotImplementedException();
        }

        public void SetTask(ITaskPerson taskPerson)
        {
            throw new NotImplementedException();
        }
    }
}

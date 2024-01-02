using UnityEngine;
using Assets.Persons;
using System;

namespace Assets.Farm
{
    public interface IPlaceTask
    {
        event Action<TaskTypes, IPlaceTask> OnUpdateStatePlace;
        ITaskPerson TaskPerson { get; }
        Vector3 Position { get; }
        bool WhosWorkingNow { get; }
        void SetTask(ITaskPerson taskPerson);
        void Execute(IPerson Who);
    }
}

using System;
using UnityEngine;
using Assets.Farm;

namespace Assets.Persons
{
    public interface ITaskPerson
    {
        event Action ChangeWorker;
        event Action OnReady;
        Vector3 Position { get; }
        bool InProcess { get; }
        bool Zanatiy { get; }
        TaskTypes TaskType { get; }
        IPlaceTask PlaceTask { get; }
        IPerson Person { get; }
        void Execute();
        void SetWorker(IPerson Who);
        void RemoveWorker();
    }
}

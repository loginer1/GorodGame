using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Persons
{
    public interface ITaskPersonNesty : ITaskPerson
    {
        Vector3 WhereNestyPosition { get; }
    }
}

using System;
using System.Collections.Generic;
using Assets.Farm;
using UnityEngine;
using System.Linq;

namespace Assets.Persons
{
    public class TaskPersonService
    {
        private Dictionary<IPlaceTask,ITaskPerson> _tasks;
        private TaskPersonFactory _taskPersonFactory;
        private IReadOnlyList<IPlaceTask> _placeTasks;

        public TaskPersonService(TaskPersonFactory taskPersonFactory)
        {
            _tasks = new Dictionary<IPlaceTask, ITaskPerson>();
            _taskPersonFactory = taskPersonFactory;
        }

        public void Init(LandingAreaModel landingAreaModel)
        {
            _placeTasks = landingAreaModel.GetPlaceTasks();
            for (int i = 0; i < _placeTasks.Count; i++)
            {
                var task = _taskPersonFactory.CreateGrowTask(_placeTasks[i]);
                _tasks.Add(_placeTasks[i], task);
                _placeTasks[i].SetTask(task);
                _placeTasks[i].OnUpdateStatePlace += OnUpdated;

            }
        }

        public void OnDisable()
        {
            for (int i = 0; i < _placeTasks.Count; i++)
            {
                _placeTasks[i].OnUpdateStatePlace -= OnUpdated;
            }
        }

        private void OnUpdated(TaskTypes state, IPlaceTask placeTask)
        {
            if(state == TaskTypes.none)
            {
                _tasks.Remove(placeTask);
            }
            else if(state == TaskTypes.plante)
            {
                _tasks.Remove(placeTask);
                var task = _taskPersonFactory.CreateGrowTask(placeTask);
                placeTask.SetTask(task);
                _tasks.Add(placeTask, task);
            }
            else if(state == TaskTypes.collect)
            {
                _tasks.Remove(placeTask);
                var task = _taskPersonFactory.CreateGrowTask(placeTask);
                placeTask.SetTask(task);

                _tasks.Add(placeTask, task);
            }

        }

        public ITaskPerson GetClosestTaskToMe(BotModel person)
        {
            ITaskPerson minDistanceTask = null;
            float minDistance = 1000;

            foreach(var i in _placeTasks)
            {
                float thisDistance = Vector3.Distance(i.Position, person._position);
                if (thisDistance < minDistance)
                {
                    if (!_tasks.ContainsKey(i))
                        continue;

                    if (i.WhosWorkingNow)
                        continue;

                    minDistanceTask = _tasks[i];
                    minDistance = thisDistance;
                }
            }

            if (minDistanceTask == null)
                throw new InvalidOperationException();

            minDistanceTask.SetWorker(person);
            return minDistanceTask;
        }
    }
}

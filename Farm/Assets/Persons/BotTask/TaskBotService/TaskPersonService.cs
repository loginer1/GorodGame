using System.Collections.Generic;
using Assets.Farm;
using UnityEngine;

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
                var task = _taskPersonFactory.CreateTask(_placeTasks[i]);
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
            _tasks.Remove(placeTask);

            if (state == TaskTypes.none)
                return;
            var task = _taskPersonFactory.CreateTask(placeTask);
            placeTask.SetTask(task);
            _tasks.Add(placeTask, task);
        }

        public ITaskPerson GetClosestTaskToMe(BotModel person, TaskTypes taskType)
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

                    if (i.WhosWorkingNow || _tasks[i].Zanatiy)
                        continue;
                    
                    if (_tasks[i].TaskType != taskType)
                        continue;
                   

                    minDistanceTask = _tasks[i];
                    minDistance = thisDistance;
                }
            }

            if (minDistanceTask != null)
            {
                minDistanceTask.SetWorker(person);
            }

            return minDistanceTask;

        }
    }
}

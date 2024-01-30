using System;
using UnityEngine;
using Assets.Persons;

namespace Assets.Farm
{
    public class PlacePlanteModel : IPlacePlanteModel, IPlaceTask
    {
        public event Action<int> OnChangePlanteModel;
        public event Action<TaskTypes, IPlaceTask> OnUpdateStatePlace;

        public ITaskPerson TaskPerson { get; private set; }
        public PlanteType PlantType => _plantModel.PlanteType;
        public bool IsEmpty => _plantModel == null;

        private IPlantModel _plantModel;

        public TaskTypes TaskType { get; private set; }
        public bool WhosWorkingNow { get; private set; }

        public int Id { get; }

        public float TimeLeftGrowing => !IsEmpty ? _plantModel.ProgressGrowing : 0;
      
        public int State { get; private set; }

        public Vector3 Position { get; }

        private GardenerService _gardenerService;


        
        public PlacePlanteModel(int id, GardenerService gardenerService, Vector3 position) 
        {
            Id = id;
            _gardenerService = gardenerService;
            State = 0;
            TaskType = TaskTypes.plante;
            Position = position;
        }

        public void Plante(IPlantModel plantModel)
        {
            if (!IsEmpty)
                throw new InvalidOperationException();
            _plantModel = plantModel;
            State = 1;
            TaskType = TaskTypes.none;


            OnChangePlanteModel?.Invoke(1);
            OnUpdateStatePlace?.Invoke(TaskTypes.none, this);

            _plantModel.OnGrewUp += OnGrewUp;
            RemoveTask();
        }

       
        public void Collect()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            _plantModel.OnGrewUp -= OnGrewUp;
            _plantModel = null;
            State = 0;
            TaskType = TaskTypes.plante;

            OnChangePlanteModel?.Invoke(0);
            OnUpdateStatePlace?.Invoke(TaskTypes.plante, this);
            RemoveTask();
        }

        public void Execute(IPerson Who)
        {
            bool isBot = false;
            if (Who is BotModel)
                isBot = true;


            if (TaskPerson != null &&TaskPerson.InProcess && isBot == false)
            {       
                _gardenerService.JustEnterTriger();
                return;
            }



            if (State == 0)
                _gardenerService.StartTimerForPlanteInPlace(this, isBot);
            else if (State == 2)
                _gardenerService.StartTimerForCollectPlanteInPlace(this, Who, isBot);
            else if (State == 1 && isBot == false)
                _gardenerService.JustEnterTriger();
        }

        public void EnterTriger(IPerson heroModel)
        {
            WhosWorkingNow = true;

            Execute(heroModel);
            TaskPerson?.RemoveWorker();
        }

        public void ExitTriger()
        {

            WhosWorkingNow = false;
            _gardenerService.ExitTriger();

        }
        public void SetTask(ITaskPerson taskPerson)
        {
            TaskPerson = taskPerson;
        }
        public void RemoveTask()
        {
            TaskPerson = null;
        }

        private void OnGrewUp()
        {
            State = 2;
            TaskType = TaskTypes.collect;

            OnChangePlanteModel?.Invoke(2);
            OnUpdateStatePlace?.Invoke(TaskTypes.collect, this);

        }
    }
}

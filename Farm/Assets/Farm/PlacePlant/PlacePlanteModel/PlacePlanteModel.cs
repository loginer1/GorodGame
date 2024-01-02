using System;
using UnityEngine;
using Assets.Persons;

namespace Assets.Farm
{
    public class PlacePlanteModel : IReadOnlyPlacePlanteModel, IPlaceTask
    {
        public event Action<int> OnChangePlanteModel;
        public event Action<TaskTypes, IPlaceTask> OnUpdateStatePlace;

        public ITaskPerson TaskPerson { get; private set; }
        public PlanteType PlantType => _plantModel.PlanteType;
        public bool IsEmpty => _plantModel == null;

        private IPlantModel _plantModel;

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
            Position = position;
        }

        public void Plante(IPlantModel plantModel)
        {
            if (!IsEmpty)
                return;
            _plantModel = plantModel;
            State = 1;

            OnChangePlanteModel?.Invoke(1);
            OnUpdateStatePlace?.Invoke(TaskTypes.none, this);

            _plantModel.OnGrewUp += OnGrewUp;
        }

       
        public void Collect()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            _plantModel.OnGrewUp -= OnGrewUp;
            _plantModel = null;
            State = 0;
            OnChangePlanteModel?.Invoke(0);
            OnUpdateStatePlace?.Invoke(TaskTypes.plante, this);

        }
        public void Execute(IPerson Who)
        {
            bool isBot = false;
            if (Who is BotModel)
                isBot = true;


            if (TaskPerson.InProcess && isBot == false)
            {
                Debug.Log(TaskPerson.InProcess);
                _gardenerService.JustEnterTriger();
                return;
            }


            Debug.Log(TaskPerson.InProcess);

            if (State == 0)
                _gardenerService.StartTimerForPlanteInPlace(this, isBot);
            else if (State == 2)
                _gardenerService.StartTimerForCollectPlanteInPlace(this, Who, isBot);
            else if (State == 1)
                _gardenerService.JustEnterTriger();
        }

        public void EnterTriger(IPerson heroModel)
        {
            WhosWorkingNow = true;

            Execute(heroModel);
            TaskPerson.RemoveWorker();
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

        private void OnGrewUp()
        {
            State = 2;
            OnChangePlanteModel?.Invoke(2);
            OnUpdateStatePlace?.Invoke(TaskTypes.collect, this);

        }


    }
}

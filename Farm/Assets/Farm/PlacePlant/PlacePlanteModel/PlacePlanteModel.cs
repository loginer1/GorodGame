using System;
using UnityEngine;
using Assets.Persons;

namespace Assets.Farm
{
    public class PlacePlanteModel : PlaceTask ,IPlacePlanteModel
    {
        public event Action<int> OnChangePlanteModel;

        public PlanteType PlantType => _plantModel.PlanteType;
        public bool IsEmpty => _plantModel == null;

        private IPlantModel _plantModel;

        public int Id { get; }

        public float TimeLeftGrowing => !IsEmpty ? _plantModel.ProgressGrowing : 0;
      
        public int State { get; private set; }


        private GardenerService _gardenerService;


        
        public PlacePlanteModel(int id, GardenerService gardenerService, Vector3 position) : base(position)
        {
            Id = id;
            _gardenerService = gardenerService;
            State = 0;
            TaskType = TaskTypes.plante;
        }

        public void Plante(IPlantModel plantModel)
        {
            if (!IsEmpty)
                throw new InvalidOperationException();        
            
            _plantModel = plantModel;
            State = 1;
            TaskType = TaskTypes.none;


            OnChangePlanteModel?.Invoke(1);

            InvokeUptadePlaceState(TaskTypes.none, this);
            _plantModel.OnGrewUp += OnGrewUp;
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
            InvokeUptadePlaceState(TaskTypes.plante, this);
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
       
        private void OnGrewUp()
        {
            State = 2;
            TaskType = TaskTypes.collect;

            OnChangePlanteModel?.Invoke(2);
            InvokeUptadePlaceState(TaskTypes.collect, this);
        }

        protected override void EnterTrigerTaskInProces()
        {
            _gardenerService.JustEnterTriger();
        }

        protected override void MyExecute(bool isBot, IPerson Who)
        {
            if (State == 0)
                _gardenerService.StartTimerForPlanteInPlace(this, isBot);
            else if (State == 2)
                _gardenerService.StartTimerForCollectPlanteInPlace(this, Who, isBot);
            else if (State == 1 && isBot == false)
                _gardenerService.JustEnterTriger();
        }
    }
}

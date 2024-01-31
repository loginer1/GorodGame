using Assets.Persons;
using UnityEngine;
using Assets.Core;


namespace Assets.Farm
{
    public class BoxModel : PlaceTask
    {       
        public PlanteType PlanteType { get; private set; }

        private TrigerTimerService _trigerTimerService;
        private bool pudnyato = false;

        private bool IsActive = false; // InProcess

        public BoxModel(TrigerTimerService trigerTimerService , Vector3 position) : base(position)
        {
            _trigerTimerService = trigerTimerService;
        }
        
        public void SetActive(bool isActive, PlanteType planteType)
        {
            IsActive = isActive;
            PlanteType = planteType;
            InvokeUptadePlaceState(TaskTypes.collect, this);
        }

        protected override void EnterTrigerTaskInProces()
        {
            _trigerTimerService.EnterTriger(0, false);
        }

        protected override void MyExecute(bool IsBot, IPerson Who)
        {
            if (pudnyato == false)
                Pudnyaty(Who);
            else
                Poklasty();
        } 
        
        private void Pudnyaty(IPerson person)
        {
            person.Pudnyaty(PlanteType);
            pudnyato = true;

            InvokeUptadePlaceState(TaskTypes.none, this);
        }

        private void Poklasty()
        {
            pudnyato = false;
            InvokeUptadePlaceState(TaskTypes.plante, this);
            RemoveTask();
        }
    }
}

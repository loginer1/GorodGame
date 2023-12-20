using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Farm
{
    public class GardenerService
    {
        private PlanteType _currentPlanteType;
        private Dictionary<PlanteType, Type> _plantForType;

        List<IPlantModel> plantModels = new List<IPlantModel>();
        Timer timer;
        PlanteFactory _planteFactory;

        public GardenerService(PlanteFactory planteFactory)
        {
            _currentPlanteType = PlanteType.Kapusta;
            InitDictinory();

            _planteFactory = planteFactory;

        }

        private void InitDictinory()
        {
            _plantForType = new Dictionary<PlanteType, Type>();

            _plantForType.Add(PlanteType.Kapusta, typeof(KapustaModel));

        }

        public void EnterTrigerPlace(PlacePlanteModel placeModel)
        {
            StartTimer(1, () => {
                var plante = _planteFactory.CreatePlanteForType(PlanteType.Kapusta);
                Debug.Log(plante);
                placeModel.Plante(plante);
                plantModels.Add(plante); ExitTrigerPlace();

            });
        }

        public void ExitTrigerPlace()
        {
            timer.Stop();
            timer = null;
        }

        private void StartTimer(float time, Action callback)
        {
            timer = new Timer(time, callback);
        }

        public void Tick(float delta)
        {
            if (timer != null)
                timer.tick(delta);

            if (plantModels.Count == 0)
                return;

            foreach(var i in plantModels)
            {
                i.Grow(delta);
            }
        }


    }

        

    class Timer
    {
        float _time;
        Action _callback;

        public Timer(float time, Action callback)
        {
            _time = time;
            _callback = callback;
        }

        public void Stop()
        {
            _callback = null;
        }

        public void tick(float delta)
        {
            _time -= delta;
            if (_time <= 0)
                _callback?.Invoke();

        }

    }

    
}

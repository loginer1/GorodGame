using System;
using Assets.Core;

namespace Assets.Farm
{
    public class PlantPlaceTimer
    {
        private float _time;
        private Action _callback;
        private TrigerTimerService _trigerTimerService;

        public PlantPlaceTimer(float time, Action callback, TrigerTimerService trigerTimerService)
        {
            _time = time;
            _callback = callback;
            _trigerTimerService = trigerTimerService;
        }

        public void Stop()
        {
            _callback = null;
        }

        public void tick(float delta)
        {
            _time -= delta;
            if (_time <= 0)
            {
                _callback?.Invoke();          
                _trigerTimerService.StopTimer();

            }
        }

    }
}

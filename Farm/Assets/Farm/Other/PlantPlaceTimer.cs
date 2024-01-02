using System;
using Assets.Core;

namespace Assets.Farm
{
    public class PlantPlaceTimer
    {
        private float _time;
        private Action _callback;
        private TrigerTimerService _trigerTimerService;
        private int _Id;
        private bool _forBot;

        public PlantPlaceTimer(float time, Action callback, TrigerTimerService trigerTimerService)
        {
            _time = time;
            _callback = callback;
            _trigerTimerService = trigerTimerService;
            _forBot = false;
        }
        public PlantPlaceTimer(float time, Action callback, TrigerTimerService trigerTimerService, int Id)
        {
            _time = time;
            _callback = callback;
            _trigerTimerService = trigerTimerService;
            _Id = Id;
            _forBot = true;
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
                if (_forBot == false)
                    _trigerTimerService.StopTimer();
                else
                    _trigerTimerService.StopTimer(_Id);
            }
        }

    }
}

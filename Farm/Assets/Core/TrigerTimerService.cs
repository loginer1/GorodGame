using Assets.Farm;
using System;

namespace Assets.Core
{
    public class TrigerTimerService
    {
        private int _trigerCount;
        private bool _shouldDeleteTimer = true;
        private PlantPlaceTimer _waitTimer;


        public void EnterTriger(float time, Action callback = null)
        {
            _trigerCount++;
            if (callback == null)
                return;

            if (_shouldDeleteTimer)
            {
                if (_trigerCount > 0)//|| _waitTimer != null)
                    _shouldDeleteTimer = false;
            }
            StartTimer(time, callback);
        }

        public void ExitTriger()
        {
            _trigerCount--;

            if (_shouldDeleteTimer)
            {
                _waitTimer = null;
            }
            else
            {
                if (_trigerCount == 0)
                {
                    _shouldDeleteTimer = true;
                    _waitTimer = null;
                }

            }
        }
        private void StartTimer(float time, Action callback)
        {

            _waitTimer = new PlantPlaceTimer(time, callback, this);
        }

        public void StopTimer()
        {
            _waitTimer.Stop();
            _waitTimer = null;
        }

        public void Tick(float delta)
        {
            if (_waitTimer != null)
                _waitTimer.tick(delta);
        }
    }
}

using Assets.Farm;
using System.Collections.Generic;
using System;

namespace Assets.Core
{
    public class TrigerTimerService
    {
        private int _trigerCount;
        private bool _shouldDeleteTimer = true;
        private PlantPlaceTimer _waitTimer;
        private List<PlantPlaceTimer> _waitTimersForBot = new List<PlantPlaceTimer>();

        public void EnterTriger(float time, bool isBot, Action callback = null)
        {
            if (isBot == false)
                _trigerCount++;

            if (_shouldDeleteTimer)
            {
                if (_trigerCount > 0)
                    _shouldDeleteTimer = false;
            }

            StartTimer(time, callback, isBot);
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

        public void StopTimer()
        {
            _waitTimer.Stop();
            _waitTimer = null;

        }

        public void StopTimer(int id)
        {
            _waitTimersForBot.RemoveAt(0);
        }

        public void Tick(float delta)
        {
            if (_waitTimer != null)
                _waitTimer.tick(delta);


            if (_waitTimersForBot.Count == 0)
                return;

            int a = _waitTimersForBot.Count;

            for (int i = 0; i < a; i++)
            {
                if (i < _waitTimersForBot.Count)
                    _waitTimersForBot[i].tick(delta);
            }

        }

        private void StartTimer(float time, Action callback, bool isBot)
        {
            if (isBot == false)
            {

                _waitTimer = new PlantPlaceTimer(time, callback, this);
            }
            else
            {
             
                _waitTimersForBot.Add( new PlantPlaceTimer(time, callback, this, 5));
            }
        }

    }
}

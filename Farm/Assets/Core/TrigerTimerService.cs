using Assets.Farm;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Assets.Core
{
    public class TrigerTimerService
    {
        private int _trigerCount;
        private bool _shouldDeleteTimer = true;
        private PlantPlaceTimer _waitTimer;
        private Dictionary<int, PlantPlaceTimer> _waitTimersForBot = new Dictionary<int, PlantPlaceTimer>();

        public void EnterTriger(float time, bool isBot, Action callback = null)
        {
            if (isBot == false)
                _trigerCount++;

            if (callback == null)
                return;

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
            _waitTimersForBot.Remove(id);
        }

        public void Tick(float delta)
        {
            if (_waitTimer != null)
                _waitTimer.tick(delta);

            Debug.Log(_trigerCount);

            if (_waitTimersForBot.Count == 0)
                return;


            for (int i = 0; i < _waitTimersForBot.Count; i++)
            {
                _waitTimersForBot[i].tick(delta);
            }
        }

        private void StartTimer(float time, Action callback, bool isBot)
        {
            if (isBot == false)
                _waitTimer = new PlantPlaceTimer(time, callback, this);
            else
            {
                int Id = _waitTimersForBot.Count;
                _waitTimersForBot.Add(Id ,new PlantPlaceTimer(time, callback, this, Id));
            }
        }

    }
}

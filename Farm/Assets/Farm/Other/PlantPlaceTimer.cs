using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Farm
{
    public class PlantPlaceTimer
    {
        private float _time;
        private Action _callback;

        public PlantPlaceTimer(float time, Action callback)
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

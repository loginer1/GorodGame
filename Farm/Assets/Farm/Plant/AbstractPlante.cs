using System;

namespace Assets.Farm
{
    public abstract class AbstractPlante : IPlantModel
    {
        public abstract Type Type { get; }

        public event Action<Type> OnGrewUp;

        public bool IsReady => _timeLeft <= 0;

        public float TimeGrowing { get; }

        private float _timeLeft;

        public AbstractPlante(IPlanteConfig planteConfig)
        {
            TimeGrowing = planteConfig.TimeGrowing;
            _timeLeft = TimeGrowing;
        }

        public void Grow(float delta)
        {
            if (IsReady)
                return;

            _timeLeft -= delta;

            if (_timeLeft <= 0)
                _timeLeft = 0;
        }
    }
}

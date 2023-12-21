using System;
using UnityEngine;

namespace Assets.Farm
{
    public abstract class AbstractPlante : IPlantModel
    {
        public abstract PlanteType PlanteType { get; }

        public event Action OnGrewUp;


        public bool IsReady => TimeLeft <= 0;

        public float TimeGrowing { get; }

        public float ProgressGrowing
        {
            get
            {
                float one = TimeGrowing / 100;
                float proccents = (TimeGrowing - TimeLeft) / one;
                return proccents / 100;
            }
        }
        public float TimeLeft { get; private set; }


        public AbstractPlante(IPlanteConfig planteConfig)
        {
            TimeGrowing = planteConfig.TimeGrowing;
            TimeLeft = TimeGrowing;
        }

        public void Grow(float delta)
        {
            if (IsReady)
                return;
            
            TimeLeft -= delta;


            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                OnGrewUp?.Invoke();
            }
        }
    }
}

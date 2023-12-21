using System;

namespace Assets.Farm
{
    public interface IPlantModel
    {
        event Action OnGrewUp;
        PlanteType PlanteType { get; }
        float ProgressGrowing { get; }
        bool IsReady { get; }
        float TimeGrowing { get; }
        void Grow(float delta);
    }
}
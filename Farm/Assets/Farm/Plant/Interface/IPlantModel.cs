namespace Assets.Farm
{
    public interface IPlantModel
    {
        bool IsReady { get; }
        float TimeGrowing { get; }
        void Grow(float delta);
    }
}
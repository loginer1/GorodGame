namespace Assets.Core
{
    public interface IGameState
    {
        void Enter();
        void Update(float delta);
        void Exit();
    }
}

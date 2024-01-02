namespace Assets.Persons
{
    public interface IBotState
    {
        void Enter();
        void Exit();
        void Update(float delta);
    }
}

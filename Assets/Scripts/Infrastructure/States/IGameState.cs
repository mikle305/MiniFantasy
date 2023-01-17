namespace Infrastructure.States
{
    public interface IGameState
    {
        public void Enter();

        public void Exit();
    }
}
namespace Additional.Abstractions.States
{
    public interface IState: IExitableState
    {
        public void Enter();
    }
}
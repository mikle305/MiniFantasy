namespace Infrastructure.GameStates
{
    public interface IPayloadedState<in TPayload>: IExitableState
    {
        public void Enter(TPayload payload);
    }
}
namespace Additional.Abstractions.States
{
    public interface IPayloadedState<in TPayload>: IExitableState
    {
        public void Enter(TPayload payload);
    }
}
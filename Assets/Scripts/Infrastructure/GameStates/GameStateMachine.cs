using Additional.Abstractions.States;
using UniDependencyInjection.Core.Model;
using IState = Additional.Abstractions.States.IState;

namespace Infrastructure.GameStates
{
    public class GameStateMachine
    {
        private IExitableState _currentState;
        private readonly IScope _scope;


        public GameStateMachine(IContainer container)
        {
            _scope = container.CreateScope();
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            
            var state = _scope.Resolve<TState>();
            _currentState = state;
            
            return state;
        }
    }
}
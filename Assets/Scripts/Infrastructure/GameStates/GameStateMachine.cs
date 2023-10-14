using UniDependencyInjection.Core;
using UniDependencyInjection.Unity;

namespace Infrastructure.GameStates
{
    public class GameStateMachine
    {
        private IExitableState _currentState;
        private IScope _scope;
        private readonly IMonoResolver _monoResolver;


        public GameStateMachine(IMonoResolver monoResolver)
        {
            _monoResolver = monoResolver;
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
            
            var state = (_scope ??= _monoResolver.CreateScope()).Resolve<TState>();
            _currentState = state;
            
            return state;
        }
    }
}
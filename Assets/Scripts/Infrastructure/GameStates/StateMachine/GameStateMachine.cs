using System;
using System.Collections.Generic;
using Additional.Abstractions.States;
using IState = Additional.Abstractions.States.IState;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _statesMap;
        private IExitableState _currentState;

        
        public GameStateMachine(Dictionary<Type, IExitableState> statesMap)
        {
            _statesMap = statesMap;
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
            
            var state = GetState<TState>();
            _currentState = state;
            
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState 
            => _statesMap[typeof(TState)] as TState;
    }
}
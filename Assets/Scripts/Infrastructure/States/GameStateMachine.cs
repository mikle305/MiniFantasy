using System;
using System.Collections.Generic;

namespace Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type,IGameState> _states;
        private IGameState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IGameState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
            };
        }

        public void Enter<TState>() where TState : IGameState
        {
            _activeState?.Exit();
            IGameState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}
using System;
using System.Collections.Generic;
using Additional.Utils;

namespace GamePlay.Units
{
    public class UnitStateMachine
    {
        private readonly Dictionary<Type, UnitState> _statesMap;
        private UnitState _currentState;

        
        public UnitStateMachine()
        {
            _statesMap = new Dictionary<Type, UnitState>();
        }

        public void AddState(UnitState state)
            => _statesMap[state.GetType()] = state;

        public void Tick() 
            => _currentState?.Tick();

        public void Enter<TState>() where TState : UnitState
        {
            if (!_statesMap.TryGetValue(typeof(TState), out UnitState newState))
                ThrowHelper.InvalidState(typeof(TState));

            _currentState?.Exit();
            newState?.Enter();
            _currentState = newState;
        }
    }
}
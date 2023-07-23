using System;
using System.Collections.Generic;
using System.Linq;
using Additional.Utils;

namespace GamePlay.Units.States
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

        public void Update()
        {
            if (_currentState != null)
                _currentState.Tick();
        }

        public void Enter<TState>() where TState : UnitState
        {
            if (!_statesMap.TryGetValue(typeof(TState), out UnitState newState))
                ThrowHelper.InvalidState(typeof(TState));

            if (_currentState != null)
                _currentState.Exit();

            newState!.Enter();
            _currentState = newState;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Additional.Utils;
using UnityEngine;

namespace GamePlay.Units.States
{
    public class UnitStateMachine : MonoBehaviour
    {
        [SerializeField] private UnitState[] _states;

        private Dictionary<Type, UnitState> _statesMap;
        private UnitState _currentState;

        private void Awake()
        {
            _statesMap = _states.ToDictionary(s => s.GetType(), s => s);
        }

        private void Update()
        {
            if (_currentState != null)
                _currentState.OnUpdate();
        }

        public void Enter<TState>() where TState : UnitState
        {
            if (!_statesMap.TryGetValue(typeof(TState), out UnitState newState))
                ThrowHelper.InvalidState(typeof(TState));

            if (_currentState == newState)
                return;

            if (_currentState != null)
                _currentState.Exit();

            newState!.Enter();
            _currentState = newState;
        }
    }
}
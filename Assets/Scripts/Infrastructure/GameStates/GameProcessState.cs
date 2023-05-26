using Additional.Abstractions.States;
using Additional.Utils;
using Domain.Units.Character;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class GameProcessState : IPayloadedState<GameObject>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IAutoSaver _autoSaver;
        private CharacterDeath _characterDeath;

        public GameProcessState(GameStateMachine stateMachine, IAutoSaver autoSaver)
        {
            _stateMachine = stateMachine;
            _autoSaver = autoSaver;
        }

        public void Enter(GameObject character)
        {
            if (!character.TryGetComponent(out _characterDeath))
                ThrowHelper.CharacterDeathComponentIsRequired();
            
            _characterDeath.Destroyed += OnDestroyed;
        }

        public void Exit()
        {
            _characterDeath.Destroyed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            _autoSaver.Stop();
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
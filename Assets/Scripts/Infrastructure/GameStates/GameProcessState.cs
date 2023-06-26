using Additional.Abstractions.States;
using Additional.Utils;
using GamePlay.Units.Animations;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class GameProcessState : IPayloadedState<GameObject>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IAutoSaver _autoSaver;
        private DestroyOnDeath _characterDestroy;

        public GameProcessState(GameStateMachine stateMachine, IAutoSaver autoSaver)
        {
            _stateMachine = stateMachine;
            _autoSaver = autoSaver;
        }

        public void Enter(GameObject character)
        {
            if (!character.TryGetComponent(out _characterDestroy))
                ThrowHelper.CharacterDeathComponentIsRequired();
            
            _characterDestroy.Destroyed += OnDestroyed;
        }

        public void Exit()
        {
            _characterDestroy.Destroyed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            _autoSaver.Stop();
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.Units.States
{
    public class IdleState : CharacterState
    {
        [SerializeField] private CharacterMovement _movement;
        
        private IInputService _inputService;

        
        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public override void OnUpdate()
        {
            if (TryAttack())
                return;

            Move();
        }

        private bool TryAttack()
        {
            bool isAttackInput = _inputService.IsAttackInvoked();
            if (isAttackInput) 
                _stateMachine.Enter<AttackState>();

            return isAttackInput;
        }

        private void Move()
        {
            Vector2 axis = _inputService.GetAxis();
            Vector3 cameraDirection = _inputService.GetCameraDirection();
            _movement.Move(axis, cameraDirection);
        }
    }
}
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class MoveState : AnyState
    {
        private UnitStateMachine _stateMachine;
        private readonly IInputService _inputService;
        private readonly CharacterMovement _movement;

        public MoveState(
            UnitStateMachine stateMachine, 
            HitOnDamage hit, 
            Health health, 
            IInputService inputService,
            CharacterMovement movement) 
            : base(stateMachine, hit, health)
        {
            _movement = movement;
            _stateMachine = stateMachine;
            _inputService = inputService;
        }

        public override void Enter()
        {
            base.Enter();
            
            MoveOrEnterIdle();
        }

        public override void Tick() 
            => MoveOrEnterIdle();

        private void MoveOrEnterIdle()
        {
            Vector2 axis = _inputService.GetAxis();

            if (axis == Vector2.zero)
                _stateMachine.Enter<IdleState>();

            Vector3 cameraDirection = _inputService.GetCameraDirection();
            _movement.Move(axis, cameraDirection);
        }
    }
}
using GamePlay.Units.Hit;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class IdleState : AnyState
    {
        private readonly UnitStateMachine _stateMachine;
        private readonly IInputService _inputService;


        public IdleState(UnitStateMachine stateMachine, HitOnDamage hit, Health health, IInputService inputService) 
            : base(stateMachine, hit, health)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
        }

        public override void Tick()
        {
            if (HandleAttack())
                return;

            HandleMove();
        }

        private bool HandleAttack()
        {
            bool isAttackInput = _inputService.IsAttackInvoked();
            if (isAttackInput) 
                _stateMachine.Enter<AttackState>();

            return isAttackInput;
        }

        private void HandleMove()
        {
            if (_inputService.GetAxis() != Vector2.zero)
                _stateMachine.Enter<MoveState>();
        }
    }
}
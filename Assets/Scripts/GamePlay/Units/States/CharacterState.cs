using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Units.States
{
    public abstract class CharacterState : UnitState
    {
        [SerializeField] protected UnitStateMachine _stateMachine;
        [SerializeField] protected HitOnDamage _hit;
        [SerializeField] private Health _health;
        

        public override void Enter()
        {
            _health.ZeroReached += _stateMachine.Enter<DeathState>;
            _hit.Started += _stateMachine.Enter<HitState>;
        }
        
        public override void OnUpdate() { }
        
        public override void Exit()
        {
            _health.ZeroReached -= _stateMachine.Enter<DeathState>;
            _hit.Started -= _stateMachine.Enter<HitState>;
        }
    }

    public class AttackState : CharacterState
    {
        [SerializeField] private CharacterAttacker _attacker;

        public override void Enter()
        {
            base.Enter();
            
            _attacker.Attack();
        }
    }
}
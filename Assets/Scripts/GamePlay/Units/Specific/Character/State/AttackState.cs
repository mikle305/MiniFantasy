namespace GamePlay.Units.Character
{
    public class AttackState : AnyState
    {
        private readonly UnitStateMachine _stateMachine;
        private readonly CharacterAttacker _attacker;

        public AttackState(UnitStateMachine stateMachine, HitOnDamage hit, Health health, CharacterAttacker attacker) 
            : base(stateMachine, hit, health)
        {
            _stateMachine = stateMachine;
            _attacker = attacker;
        }

        public override void Enter()
        {
            base.Enter();

            _attacker.AttackEnded += EnterIdleState;
            _attacker.Attack();
        }

        private void EnterIdleState()
            => _stateMachine.Enter<IdleState>();
    }
}
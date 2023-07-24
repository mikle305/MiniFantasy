namespace GamePlay.Units.Character
{
    public abstract class AnyState : UnitState
    {
        private readonly UnitStateMachine _stateMachine;
        private readonly HitOnDamage _hit;
        private readonly Health _health;


        protected AnyState(UnitStateMachine stateMachine, HitOnDamage hit, Health health)
        {
            _stateMachine = stateMachine;
            _health = health;
            _hit = hit;
        }
        
        public override void Enter()
        {
            _health.ZeroReached += _stateMachine.Enter<DeathState>;
            _hit.Started += _stateMachine.Enter<HitState>;
        }
        
        public override void Exit()
        {
            _health.ZeroReached -= _stateMachine.Enter<DeathState>;
            _hit.Started -= _stateMachine.Enter<HitState>;
        }
    }
}
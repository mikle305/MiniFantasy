namespace GamePlay.Units.Character
{
    public class HitState : AnyState
    {
        private readonly UnitStateMachine _stateMachine;
        private readonly HitOnDamage _hit;

        public HitState(UnitStateMachine stateMachine, HitOnDamage hit, Health health) 
            : base(stateMachine, hit, health)
        {
            _stateMachine = stateMachine;
            _hit = hit;
        }

        public override void Enter()
        {
            base.Enter();
            _hit.Ended += _stateMachine.Enter<IdleState>;
        }

        public override void Exit()
        {
            base.Exit();
            _hit.Ended -= _stateMachine.Enter<IdleState>;
        }
    }
}
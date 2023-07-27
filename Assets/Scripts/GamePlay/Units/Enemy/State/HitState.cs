using GamePlay.Units.Hit;

namespace GamePlay.Units.Enemy
{
    public class HitState : AnyState
    {
        private readonly UnitStateMachine _stateMachine;
        private readonly HitOnDamage _hit;
        private readonly Follower _follower;

        public HitState(
            UnitStateMachine stateMachine, 
            HitOnDamage hit, 
            Health health,
            Follower follower) 
            : base(stateMachine, hit, health)
        {
            _follower = follower;
            _stateMachine = stateMachine;
            _hit = hit;
        }

        public override void Enter()
        {
            base.Enter();

            _follower.Block();
            _hit.Ended += _stateMachine.Enter<IdleState>;
        }

        public override void Exit()
        {
            base.Exit();
            _hit.Ended -= _stateMachine.Enter<IdleState>;
        }
    }
}
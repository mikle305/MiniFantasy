using GamePlay.Units.Hit;

namespace GamePlay.Units.Enemy
{
    public class IdleState : AnyState
    {
        private readonly UnitStateMachine _stateMachine;
        private readonly Follower _follower;


        public IdleState(
            UnitStateMachine stateMachine, 
            HitOnDamage hit, 
            Health health,
            Follower follower) 
            : base(stateMachine, hit, health)
        {
            _follower = follower;
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            base.Enter();

            _follower.Unblock();
        }
    }
}
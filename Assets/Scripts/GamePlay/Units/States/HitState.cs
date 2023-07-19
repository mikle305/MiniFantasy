namespace GamePlay.Units.States
{
    public class HitState : CharacterState
    {
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
namespace GamePlay.Units.Enemy
{
    public class DeathState : UnitState
    {
        private readonly Death.Death _death;
        private readonly Follower _follower;


        public DeathState(Death.Death death, Follower follower)
        {
            _follower = follower;
            _death = death;
        }
        
        public override void Enter()
        {
            _follower.Block();
            _death.Die();
        }
    }
}
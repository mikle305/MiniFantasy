namespace GamePlay.Units.States
{
    public class DeathState : UnitState
    {
        private readonly Death _death;


        public DeathState(Death death)
        {
            _death = death;
        }
        
        public override void Enter()
        {
            _death.Die();
        }
    }
}
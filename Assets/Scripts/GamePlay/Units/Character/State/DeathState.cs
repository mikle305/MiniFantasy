namespace GamePlay.Units.Character
{
    public class DeathState : UnitState
    {
        private readonly Death.Death _death;


        public DeathState(Death.Death death)
        {
            _death = death;
        }
        
        public override void Enter()
        {
            _death.Die();
        }
    }
}
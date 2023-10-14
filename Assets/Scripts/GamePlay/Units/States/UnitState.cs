namespace GamePlay.Units
{
    public abstract class UnitState
    {
        public virtual void Enter() {}
        public virtual void Tick() {}
        public virtual void Exit() {}
    }
}
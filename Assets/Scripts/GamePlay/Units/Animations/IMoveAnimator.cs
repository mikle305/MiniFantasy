namespace GamePlay.Units
{
    public interface IMoveAnimator
    {
        public void UpdateMoving(float speedCoefficient);
        
        public void StopMoving();
    }
}
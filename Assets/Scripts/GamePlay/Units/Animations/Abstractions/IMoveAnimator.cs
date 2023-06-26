namespace GamePlay.Units.Animations
{
    public interface IMoveAnimator
    {
        public void UpdateMoving(float speedCoefficient);
        
        public void StopMoving();
    }
}
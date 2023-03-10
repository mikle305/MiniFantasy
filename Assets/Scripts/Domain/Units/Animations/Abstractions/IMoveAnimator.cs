namespace Domain.Units.Animations.Abstractions
{
    public interface IMoveAnimator
    {
        public void UpdateMoving(float speedCoefficient);
        
        public void StopMoving();
    }
}
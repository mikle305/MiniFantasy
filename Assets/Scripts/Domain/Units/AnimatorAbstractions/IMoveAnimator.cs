namespace Domain.Units.AnimatorAbstractions
{
    public interface IMoveAnimator
    {
        public void UpdateMoving(float speedCoefficient);
        
        public void StopMoving();
    }
}
namespace Domain.Units.Animations.Abstractions
{
    public interface IDieAnimator
    {
        public void PlayDie();
        
        public void SetDieDuration(float duration);
    }
}
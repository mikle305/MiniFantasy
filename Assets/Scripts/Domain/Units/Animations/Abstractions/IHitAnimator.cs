namespace Domain.Units.Animations.Abstractions
{
    public interface IHitAnimator
    {
        public void PlayHit();

        public void SetHitDuration(float duration);
    }
}
namespace Domain.Enemies.Ninja
{
    public interface INinjaAnimator
    {
        public void PlayMeleeAttack();
        
        public void PlayHit();
        
        public void PlayDie();

        public void UpdateMoving(float speedCoefficient);
        
        public void StopMoving();
        
        public void SetAttackDuration(float duration);
    }
}
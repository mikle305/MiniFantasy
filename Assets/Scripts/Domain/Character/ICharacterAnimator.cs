namespace Domain.Character
{
    public interface ICharacterAnimator
    {
        public void PlayMeleeAttack();
        
        public void PlayHit();
        
        public void PlayDie();

        public void UpdateMoving(float speedCoefficient);
        
        public void StopMoving();
        
        public void SetAttackDuration(float duration);
    }
}
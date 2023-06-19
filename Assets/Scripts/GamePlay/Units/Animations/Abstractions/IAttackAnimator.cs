namespace Domain.Units.Animations.Abstractions
{
    public interface IAttackAnimator
    {
        public void PlayMeleeAttack();
        
        public void SetAttackDuration(float duration);
    }
}
namespace Domain.Units.AnimatorAbstractions
{
    public interface IAttackAnimator
    {
        public void PlayMeleeAttack();
        
        public void SetAttackDuration(float duration);
    }
}
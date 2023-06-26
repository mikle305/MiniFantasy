namespace GamePlay.Units.Animations
{
    public interface IAttackAnimator
    {
        public void PlayMeleeAttack();
        
        public void SetAttackDuration(float duration);
    }
}
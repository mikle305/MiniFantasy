namespace GamePlay.Units
{
    public interface IAttackAnimator
    {
        public void PlayMeleeAttack();
        
        public void SetAttackDuration(float duration);
    }
}
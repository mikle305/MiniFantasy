using System;

namespace Domain.Units.Health
{
    public interface IDamageable
    {
        public event Action<float> Damaged;
        
        public event Action ZeroReached;

        public void TakeDamage(float damage);
    }
}
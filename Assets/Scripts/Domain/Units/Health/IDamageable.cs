using System;

namespace Domain.Units.Health
{
    public interface IDamageable
    {
        public event Action<float> Damaged;
        
        public void TakeDamage(float value);
    }
}
using System;

namespace Domain.Units.Health
{
    public interface IHealth
    {
        public event Action Changed;
        
        public event Action ZeroReached;

        public void Init(float current, float max);
        
        public float CurrentValue { get; }

        public float MaxValue { get; }

        public void TakeDamage(float damage);

        public void TakeHeal(float health);
    }
}
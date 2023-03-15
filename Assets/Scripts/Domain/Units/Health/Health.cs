using System;
using Additional.Utils;
using Domain.StatsSystem;
using UnityEngine;

namespace Domain.Units.Health
{
    public abstract class Health : MonoBehaviour, IDamageable
    {
        protected DefaultStat _current;
        protected ModifiableStat _max;

        public event Action<float> Damaged;
        public event Action ZeroReached;
        
        public float CurrentValue => 
            _current.GetValue();

        public float MaxValue => 
            _max.GetValue();

        public void TakeHeal(float health)
        {
            ValidateValue(health);
            if (CurrentValue == 0)
                return;
            
            ApplyHeal(health);
        }

        public void TakeDamage(float damage)
        {
            ValidateValue(damage);
            if (CurrentValue == 0)
                return;
            
            ApplyDamage(damage);
        }

        protected virtual void ApplyHeal(float health)
        {
            float sum = _current.GetValue() + health;
            float maxValue = _max.GetValue();
            _current.SetValue(sum > maxValue ? maxValue : sum);
        }

        protected virtual void ApplyDamage(float damage)
        {
            float diff = _current.GetValue() - damage;
            Damaged?.Invoke(CurrentValue);

            if (diff > 0)
            {
                _current.SetValue(diff);
            }
            else
            {
                _current.SetValue(0);
                ZeroReached?.Invoke();
            }
        }

        private static void ValidateValue(float value)
        {
            if (value <= 0)
                ThrowHelper.ValueLessThanZero();
        }
    }
}
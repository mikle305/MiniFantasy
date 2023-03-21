using System;
using Additional.Constants;
using Additional.Utils;
using Domain.StatsSystem;
using UnityEngine;

namespace Domain.Units.Health
{
    public abstract class Health : MonoBehaviour, IHealth
    {
        protected DefaultStat _current;
        protected ModifiableStat _max;

        public virtual event Action Changed;
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
            
            if (Math.Abs(MaxValue - CurrentValue) < Constants.Epsilon)
                return;
            
            ApplyHeal(health);
            Changed?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            ValidateValue(damage);
            if (CurrentValue == 0)
                return;
            
            ApplyDamage(damage);
            Changed?.Invoke();
            
            if (CurrentValue == 0)
                ZeroReached?.Invoke();
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
            if (diff > 0)
                _current.SetValue(diff);
            else
                _current.SetValue(0);
        }

        protected void InvokeChanged() =>
            Changed?.Invoke();

        private static void ValidateValue(float value)
        {
            if (value <= 0)
                ThrowHelper.ValueLessThanZero();
        }
    }
}
using System;
using Additional.Constants;
using Additional.Utils;
using GamePlay.StatsSystem;
using UnityEngine;

namespace GamePlay.Units.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        protected DefaultStat _current;
        protected ModifiableStat _max;

        public event Action Changed;
        public event Action ZeroReached;
        
        
        public void Init(float current, float max)
        {
            _max = new ModifiableStat(max);
            _current = new DefaultStat(current);
        }
        
        public float CurrentValue 
            => _current.GetValue();

        public float MaxValue 
            => _max.GetValue();

        public void TakeHeal(float health)
        {
            ValidateValue(health);
            if (CurrentValue == 0)
                return;
            
            if (Math.Abs(MaxValue - CurrentValue) < Constants.Epsilon)
                return;
            
            ApplyHeal(health);
            InvokeChanged();
        }

        public void TakeDamage(float damage)
        {
            ValidateValue(damage);
            if (CurrentValue == 0)
                return;
            
            ApplyDamage(damage);
            InvokeChanged();
            InvokeZeroReached();
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

        private void InvokeZeroReached()
        {
            if (CurrentValue == 0)
                ZeroReached?.Invoke();
        }

        private void InvokeChanged()
            => Changed?.Invoke();

        private static void ValidateValue(float value)
        {
            if (value <= 0)
                ThrowHelper.ValueLessThanZero();
        }
    }
}
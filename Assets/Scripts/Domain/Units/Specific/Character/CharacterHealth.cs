using System;
using Additional.Utils;
using Domain.StatsSystem;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Specific.Character
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        private DefaultStat _current;
        private ModifiableStat _max;
        private bool _isInitialized;

        public event Action<float> Damaged;
        
        
        public void Init(float current, float max)
        {
            if (_isInitialized)
                return;
            
            _max = new ModifiableStat(max);
            _current = new DefaultStat(current);
            _isInitialized = true;
        }

        public float MaxValue()
            => _max.BaseValue;

        public float CurrentValue()
            => _current.GetValue();

        public float MaxValueWithBonuses()
            => _max.GetValue();

        public void TakeHeal(float value)
        {
            ValidateValue(value);
            
            float sum = _current.GetValue() + value;
            float maxValue = _max.GetValue();
            _current.SetValue(sum > maxValue ? maxValue : sum);
        }

        public void TakeDamage(float value)
        {
            ValidateValue(value);
            
            float diff = _current.GetValue() - value;
            _current.SetValue(diff < 0 ? 0 : diff);
            Damaged?.Invoke(CurrentValue());
        }

        private static void ValidateValue(float value)
        {
            if (value <= 0)
                ThrowHelper.ValueLessThanZero();
        }
    }
}
using System;
using Additional.Utils;
using Domain.StatsSystem;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Specific.Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _defaultValue;
        
        private DefaultStat _current;
        private DefaultStat _max;

        public event Action<float> Damaged;
        
        
        private void Awake()
        {
            _max = new DefaultStat(_defaultValue);
            _current = new DefaultStat(_defaultValue);
        }

        public float CurrentValue()
            => _current.GetValue();

        public float MaxValue()
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
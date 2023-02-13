﻿using System;
using Domain.Units.Stats.System;
using UnityEngine;

namespace Domain.Units.Stats.Components
{
    public class Health : MonoBehaviour
    {
        private DefaultStat _current;
        private ModifiableStat _max;
        private bool _isInitialized;

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

        public virtual void Heal(float value)
        {
            ValidateValue(value);
            
            float sum = _current.GetValue() + value;
            float maxValue = _max.GetValue();
            
            _current.SetValue(sum > maxValue ? maxValue : sum);
        }

        public virtual void TakeDamage(float value)
        {
            ValidateValue(value);
            
            float diff = _current.GetValue() - value;
            
            _current.SetValue(diff < 0 ? 0 : diff);
        }

        private static void ValidateValue(float value)
        {
            if (value <= 0)
                throw new ArgumentException("Value must be not not less than zero");
        }
    }
}
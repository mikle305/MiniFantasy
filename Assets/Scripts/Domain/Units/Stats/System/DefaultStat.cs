using System;

namespace Domain.Units.Stats.System
{
    public class DefaultStat : IStat
    {
        private float _value;

        public event Action<float, float> ValueChanged;
        

        public float GetValue() 
            => _value;

        public void SetValue(float value)
        {
            float oldValue = _value;
            _value = value;
            
            ValueChanged?.Invoke(oldValue, _value);
        }
    }
}
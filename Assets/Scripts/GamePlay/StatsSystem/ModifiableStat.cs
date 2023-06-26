using System;
using System.Collections.Generic;

namespace GamePlay.StatsSystem
{
    public class ModifiableStat : IStat
    {
        private readonly List<StatModifier> _modifiers;
        private float _baseValue;
        private float _finalValue;

        public event Action<float, float> ValueChanged;


        public ModifiableStat(float baseValue = 0.0f)
        {
            _modifiers = new List<StatModifier>();
            _baseValue = baseValue;
            CacheFinalValue();
        }

        public float BaseValue
        {
            get => _baseValue;
            set
            {
                _baseValue = value;
                CacheFinalValue();
            }
        }

        public float GetValue() 
            => _finalValue;

        public void AddModifier(StatModifier modifier)
        {
            _modifiers.Add(modifier);
            CacheFinalValue();
        }

        public bool RemoveModifier(StatModifier modifier)
        {
            bool result = _modifiers.Remove(modifier);
            CacheFinalValue();
            return result;
        }

        private void CacheFinalValue()
        {
            float oldValue = _finalValue;
            _finalValue = CalculateFinalValue();
            
            ValueChanged?.Invoke(oldValue, _finalValue);
        }

        private float CalculateFinalValue()
        {
            CalculateModifiers(out float additionBefore, out float coefficient, out float additionAfter);
            
            float modifiedValue = (_baseValue + additionBefore) * coefficient + additionAfter;
            
            return MathF.Round(modifiedValue, 2);
        }

        private void CalculateModifiers(out float additionBefore, out float coefficient, out float additionAfter)
        {
            additionBefore = 0;
            additionAfter = 0;
            coefficient = 1;
            
            foreach (StatModifier modifier in _modifiers)
            {
                switch (modifier.Type)
                {
                    case ModifierType.AdditionBefore:
                        additionBefore += modifier.Value;
                        break;
                    case ModifierType.Coefficient:
                        coefficient += modifier.Value;
                        break;
                    case ModifierType.AdditionAfter:
                        additionAfter += modifier.Value;
                        break;
                    default:
                        throw new Exception("Unhandled modifier type");
                }
            }
        }
    }
}
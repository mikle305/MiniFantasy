using System;

namespace GamePlay.Units
{
    public interface ICharacteristic
    {
        public event Action ValueChanged;

        public float CurrentValue { get; }
        public float MaxValue { get; }
    }
}
namespace Domain.Units.Stats.System
{
    public class StatModifier
    {
        /// <summary>
        /// With type coefficient value 0.1 equals +10%, -0.1 equals -10%
        /// </summary>
        public StatModifier(float value, ModifierType type)
        {
            Value = value;
            Type = type;
        }

        public float Value { get; }

        public ModifierType Type { get; }
    }
}
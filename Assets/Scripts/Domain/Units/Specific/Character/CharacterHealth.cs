using Domain.StatsSystem;

namespace Domain.Units.Specific.Character
{
    public class CharacterHealth : Health.Health
    {
        public float MaxValueWithoutBonuses =>
            _max.BaseValue;

        public void Init(float current, float max)
        {
            _max = new ModifiableStat(max);
            _current = new DefaultStat(current);
        }
    }
}
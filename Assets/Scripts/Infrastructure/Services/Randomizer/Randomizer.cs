using Additional.Utils;
using UnityEngine;

namespace Infrastructure.Services
{
    public class Randomizer : IRandomizer
    {
        public bool TryChancePercents(float percents)
        {
            if (percents > 100)
                ThrowHelper.InvalidChance();

            return TryChanceCoefficient(percents / 100);
        }

        public bool TryChanceCoefficient(float coefficient)
        {
            if (coefficient > 1)
                ThrowHelper.InvalidChance();

            return Random.Range(0f, 1f) < coefficient;
        }

        public int Generate(int min, int max)
        {
            return min == max
                ? min
                : Random.Range(min, max + 1);
        }
    }
}
namespace Infrastructure.Services
{
    public interface IRandomizer
    {
        public bool TryChancePercents(float percents);
        
        public bool TryChanceCoefficient(float coefficient);
        
        public int Generate(int min, int max);
        public float Generate(float min, float max);

        /// <summary>
        /// Returns -1 or 1 randomly generated
        /// </summary>
        /// <returns></returns>
        public int GenerateSign();
    }
}
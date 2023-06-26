namespace Infrastructure.Services
{
    public interface IRandomizer
    {
        public bool TryChancePercents(float percents);
        
        public bool TryChanceCoefficient(float coefficient);
        
        public int Generate(int min, int max);
    }
}
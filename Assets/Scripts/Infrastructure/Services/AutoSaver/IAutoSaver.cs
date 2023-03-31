namespace Infrastructure.Services
{
    public interface IAutoSaver
    {
        public void Start();
        
        public void Stop();
    }
}
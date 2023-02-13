namespace Infrastructure.Services.AutoSaver
{
    public interface IAutoSaver : IService
    {
        public void Start();
        
        public void Stop();
    }
}
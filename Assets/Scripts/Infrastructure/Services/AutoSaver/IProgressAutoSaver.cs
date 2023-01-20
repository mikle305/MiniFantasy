namespace Infrastructure.Services.AutoSaver
{
    public interface IProgressAutoSaver : IService
    {
        public void Start();
        
        public void Stop();
    }
}
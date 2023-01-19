using Data;

namespace Infrastructure.Services.Storage
{
    public interface IStorageService : IService
    {
        public void SaveProgress();
        
        public PlayerProgress LoadProgress();
    }
}
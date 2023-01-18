using Data;

namespace Infrastructure.Services.SaveLoad
{
    public interface IStorageService : IService
    {
        public void SaveProgress();
        
        public PlayerProgress LoadProgress();
    }
}
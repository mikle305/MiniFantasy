using Data;

namespace Infrastructure.Services
{
    public interface IStorageService
    {
        public void SaveProgress();
        
        public GameProgress LoadProgress();
    }
}
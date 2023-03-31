using Data;

namespace Infrastructure.Services
{
    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerProgress progress);
    }
}
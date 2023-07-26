using Data;

namespace Infrastructure.Services
{
    public interface ISavedProgressReader
    {
        public void ReadProgress(PlayerProgress progress);
    }
}
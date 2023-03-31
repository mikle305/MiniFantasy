using Data;

namespace Infrastructure.Services
{
    public interface ISavedProgressWriter : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress progress);
    }
}
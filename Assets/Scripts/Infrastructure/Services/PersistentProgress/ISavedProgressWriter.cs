using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgressWriter : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress progress);
    }
}
using Data;

namespace Infrastructure.Services.Progress
{
    public interface ISavedProgressWriter : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress progress);
    }
}
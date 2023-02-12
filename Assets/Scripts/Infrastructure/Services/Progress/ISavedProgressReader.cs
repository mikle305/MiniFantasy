using Data;

namespace Infrastructure.Services.Progress
{
    public interface ISavedProgressReader
    {
        public void LoadProgress(PlayerProgress progress);
    }
}
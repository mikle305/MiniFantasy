using Data;

namespace Infrastructure.Services
{
    public interface ISavedProgressWriter : ISavedProgressReader
    {
        public void WriteProgress(PlayerProgress progress);
    }
}
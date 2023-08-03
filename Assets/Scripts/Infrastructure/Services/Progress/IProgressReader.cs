using Data;

namespace Infrastructure.Services
{
    public interface IProgressReader
    {
        public void ReadProgress(GameProgress progress);
    }
}
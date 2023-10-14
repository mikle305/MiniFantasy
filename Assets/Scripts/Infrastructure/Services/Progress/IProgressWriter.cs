using Data;

namespace Infrastructure.Services
{
    public interface IProgressWriter : IProgressReader
    {
        public void WriteProgress(GameProgress progress);
    }
}
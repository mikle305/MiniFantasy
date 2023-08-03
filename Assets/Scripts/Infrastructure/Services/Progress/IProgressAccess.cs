using Data;

namespace Infrastructure.Services
{
    public interface IProgressAccess
    {
        public GameProgress Progress { get; set; }
    }
}
using Data;

namespace Infrastructure.Services
{
    public class ProgressAccess : IProgressAccess
    {
        public GameProgress Progress { get; set; }
    }
}
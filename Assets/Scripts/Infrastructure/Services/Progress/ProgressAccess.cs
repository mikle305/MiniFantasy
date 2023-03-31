using Data;

namespace Infrastructure.Services
{
    public class ProgressAccess : IProgressAccess
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
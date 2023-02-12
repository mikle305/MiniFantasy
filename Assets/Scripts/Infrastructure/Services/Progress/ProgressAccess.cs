using Data;

namespace Infrastructure.Services.Progress
{
    public class ProgressAccess : IProgressAccess
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
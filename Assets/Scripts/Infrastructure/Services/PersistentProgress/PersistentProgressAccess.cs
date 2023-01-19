using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public class PersistentProgressAccess : IPersistentProgressAccess
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
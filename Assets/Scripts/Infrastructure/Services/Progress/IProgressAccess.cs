using Data;

namespace Infrastructure.Services
{
    public interface IProgressAccess
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
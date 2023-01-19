using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressAccess: IService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
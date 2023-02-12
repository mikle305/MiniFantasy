using Data;

namespace Infrastructure.Services.Progress
{
    public interface IProgressAccess: IService
    {
        public PlayerProgress PlayerProgress { get; set; }
    }
}
using StaticData;

namespace Infrastructure.Services
{
    public interface IConfigAccess
    {
        public HudConfiguration FindHudConfig();
    }
}
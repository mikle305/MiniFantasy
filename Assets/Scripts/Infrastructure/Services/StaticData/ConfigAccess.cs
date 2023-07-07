using Additional.Constants;
using StaticData;

namespace Infrastructure.Services
{
    public class ConfigAccess : IConfigAccess
    {
        private readonly IAssetProvider _assetProvider;
        private HudConfiguration _hudConfig;

        
        public ConfigAccess(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public HudConfiguration FindHudConfig()
            => _hudConfig ??= _assetProvider.Load<HudConfiguration>(AssetPath.HudConfigPath);
    }
}
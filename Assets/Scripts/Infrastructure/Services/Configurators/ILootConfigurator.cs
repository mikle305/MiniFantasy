using GamePlay.LootSystem;
using StaticData;

namespace Infrastructure.Services
{
    public interface ILootConfigurator
    {
        public void Configure(LootPiece lootPiece, LootId lootId);
    }

    public class LootConfigurator : ILootConfigurator
    {
        private readonly IStaticDataService _staticDataService;

        
        public LootConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public void Configure(LootPiece lootPiece, LootId lootId)
        {
            LootData lootData = _staticDataService.GetLootData(lootId);
            InitLootPiece(lootPiece, lootData);
            InitFx(lootPiece, lootData);
            InitAnimation(lootPiece, lootData);
        }

        private static void InitLootPiece(LootPiece lootPiece, LootData lootData) 
            => lootPiece.Init(lootData);

        private static void InitFx(LootPiece lootPiece, LootData lootData)
        {
            if (lootPiece.TryGetComponent(out LootEffect lootEffect))
                lootEffect.Init(lootData.LootEffect);
        }

        private static void InitAnimation(LootPiece lootPiece, LootData lootData)
        {
            if (lootPiece.TryGetComponent(out LootScaleAnimation lootScaleAnimation))
                
        }
    }
}
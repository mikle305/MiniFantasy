using GamePlay.LootSystem;

namespace Infrastructure.Services
{
    public interface ILootConfigurator
    {
        public void Configure(LootPiece lootPiece, LootId lootId);
    }
}
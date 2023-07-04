using GamePlay.Units.Loot;

namespace Infrastructure.Services
{
    public interface ILootConfigurator
    {
        public void Configure(LootPiece lootPiece, LootTypeId lootId);
    }
}
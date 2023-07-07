using GamePlay.LootSystem;
using UI.Inventory;

namespace Infrastructure.Services
{
    public interface IUiConfigurator
    {
        public void ConfigureInventoryItem(ItemView itemView, LootId lootId, int count);
    }
}
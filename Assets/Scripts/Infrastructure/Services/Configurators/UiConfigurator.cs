using GamePlay.LootSystem;
using StaticData;
using UI.Inventory;

namespace Infrastructure.Services
{
    public class UiConfigurator : IUiConfigurator
    {
        private readonly IStaticDataService _staticDataService;

        public UiConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public void ConfigureInventoryItem(ItemView itemView, LootId lootId, int count)
        {
            if (_staticDataService.GetLootData(lootId) is not InventoryLootData lootData)
                return;
            
            itemView.ShowCount(count);
            if (itemView.LootId == lootId)
                return;

            itemView.LootId = lootId;
            itemView.ShowName(lootData.Name ?? string.Empty);
            itemView.ShowRarity(lootData.ItemRarity);
        }
    }
}
using Additional.Extensions;
using Additional.Utils;
using GamePlay.LootSystem;
using StaticData;
using UI.Inventory;

namespace Infrastructure.Services
{
    public class UiConfigurator : IUiConfigurator
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IConfigAccess _configAccess;

        public UiConfigurator(IStaticDataService staticDataService, IConfigAccess configAccess)
        {
            _staticDataService = staticDataService;
            _configAccess = configAccess;
        }
        
        public void ConfigureItemView(ItemView itemView, LootId lootId)
        {
            InitItemData(itemView);
            UpdateItem(itemView, lootId);
        }

        private void InitItemData(ItemView itemView)
        {
            HudConfiguration hudConfig = _configAccess.FindHudConfig();
            itemView.InitData(hudConfig);
        }

        private void UpdateItem(ItemView itemView, LootId lootId)
        {
            var lootData = _staticDataService.GetLootData(lootId) as InventoryLootData;
            if (lootData == null)
                ThrowHelper.InvalidLootType<InventoryLootData>();
            
            if (itemView.LootId == lootId)
                return;

            itemView.LootId = lootId;
            itemView.ShowName(lootData!.Name ?? string.Empty);
            itemView.ShowRarity(lootData.ItemRarity);
        }
    }
}
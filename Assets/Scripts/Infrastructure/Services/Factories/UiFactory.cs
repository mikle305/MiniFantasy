using Additional.Constants;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;
using UI;
using UI.Inventory;
using UnityEngine;

namespace Infrastructure.Services
{
    public class UiFactory : IUiFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;


        public UiFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
        }

        public Hud CreateHud(GameObject character, Camera uiCamera)
        { 
            var hud = _assetProvider.Instantiate<Hud>(AssetPath.HudPath);

            InitUiCamera(hud.Canvas, uiCamera);
            InitHpBar(hud.HealthBar, character);
            InitInventoryView(hud.InventoryView, character);

            return hud;
        }

        public SlotView CreateSlot(Slot slot, Transform slotsGrid)
        {
            var slotView = _assetProvider.Instantiate<SlotView>(AssetPath.SlotPath, slotsGrid.position, slotsGrid);
            slotView.Init(slot);
            return slotView;
        }

        public ItemView CreateItem(LootId lootId, Transform itemHolder)
        {
            LootData lootData = _staticDataService.GetLootData(lootId);
            return _assetProvider.Instantiate<ItemView>(lootData.IconPath, itemHolder.position, itemHolder);
        }

        private void InitUiCamera(Canvas hudCanvas, Camera uiCamera)
        {
            hudCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            hudCanvas.worldCamera = uiCamera;
        }

        private void InitInventoryView(InventoryView inventoryView, GameObject character)
        {
            var inventory = character.GetComponent<Inventory>();
            inventoryView.Init(inventory);
        }

        private void InitHpBar(HudStatBar healthBar, GameObject character)
        {
            var health = character.GetComponent<Health>();
            healthBar.Init(health);
        }
    }
}
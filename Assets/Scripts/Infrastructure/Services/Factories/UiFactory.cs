using Additional.Constants;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;
using UI;
using UI.InventorySystem;
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

            InitHudCanvas(hud.Canvas, uiCamera);
            InitHpBar(hud.HealthBar, character);
            InitInventoryView(hud.InventoryView, character);

            return hud;
        }

        public SlotView CreateSlot(Slot slot, Transform slotsGrid)
        {
            string slotPath = slot.IsHotSlot ? AssetPath.HotSlotPath : AssetPath.SlotPath;
            var slotView = _assetProvider.Instantiate<SlotView>(slotPath, slotsGrid);
            var slotActor = new SlotActor(slot, slotView);
            slotView.Init(slotActor);
            return slotView;
        }

        public GameObject CreateItem(LootId lootId, Transform slot)
        {
            LootData lootData = _staticDataService.GetLootData(lootId);
            var itemIcon = _assetProvider.Instantiate<RectTransform>(lootData.IconPath, slot);
            SetItemSize(itemIcon, slot);
            return itemIcon.gameObject;
        }

        private static void InitHudCanvas(Canvas hudCanvas, Camera uiCamera)
        {
            hudCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            hudCanvas.worldCamera = uiCamera;
        }

        private static void InitInventoryView(InventoryView inventoryView, GameObject character)
        {
            var inventory = character.GetComponent<Inventory>();
            var inventoryActor = new InventoryActor(inventory, inventoryView);
            inventoryView.Init(inventoryActor);
        }

        private static void InitHpBar(HudStatBar healthBar, GameObject character)
        {
            var health = character.GetComponent<Health>();
            var statActor = new StatActor(health, healthBar);
            healthBar.Init(statActor);
        }

        private static void SetItemSize(RectTransform itemIcon, Transform slot)
        {
            Vector2 scaleFactor = ((RectTransform)slot).rect.size / itemIcon.rect.size;
            Vector3 itemScale = itemIcon.localScale;
            itemScale = new Vector3(itemScale.x * scaleFactor.x, itemScale.y * scaleFactor.y, itemScale.z);
            itemIcon.localScale = itemScale;
        }
    }
}
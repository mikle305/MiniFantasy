using Additional.Constants;
using GamePlay.InventorySystem;
using GamePlay.Units;
using UI;
using UnityEngine;

namespace Infrastructure.Services
{
    public class UiFactory : IUiFactory
    {
        private IAssetProvider _assetProvider;


        public UiFactory(IAssetProvider assetProvider)
        {
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
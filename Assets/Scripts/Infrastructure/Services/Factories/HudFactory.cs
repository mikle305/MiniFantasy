using Additional.Constants;
using GamePlay.InventorySystem;
using GamePlay.Units;
using UI;
using UI.InventorySystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public class HudFactory : IHudFactory
    {
        private readonly IAssetProvider _assetProvider;
        

        public HudFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public Hud CreateHud(GameObject character, Camera uiCamera)
        { 
            var hud = _assetProvider.Instantiate<Hud>(AssetPath.HudPath);
            InitHudCanvas(hud.Canvas, uiCamera);
            InitHealthActor(hud.HealthBar, character);
            InitInventoryActor(hud.InventoryView, character);
            return hud;
        }
        
        private static void InitHudCanvas(Canvas hudCanvas, Camera uiCamera)
        {
            hudCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            hudCanvas.worldCamera = uiCamera;
        }

        private static void InitInventoryActor(InventoryView inventoryView, GameObject character)
        {
            var inventory = character.GetComponent<Inventory>();
            var inventoryActor = new InventoryActor(inventory, inventoryView);
            inventoryView.Init(inventoryActor);
        }

        private static void InitHealthActor(HudStatBar healthBar, GameObject character)
        {
            var health = character.GetComponent<Health>();
            var statActor = new StatActor(health, healthBar);
            healthBar.Init(statActor);
        }
    }
}
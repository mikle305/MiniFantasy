using Additional.Constants;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using StaticData;
using TMPro.EditorUtilities;
using UI.InventorySystem;
using UnityEngine;

namespace Infrastructure.Services
{
    public class InventoryUiFactory : IInventoryUiFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly IObjectsProvider _objectsProvider;


        public InventoryUiFactory(
            IAssetProvider assetProvider,
            IStaticDataService staticDataService,
            IObjectsProvider objectsProvider)
        {
            _objectsProvider = objectsProvider;
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
        }

        public SlotView CreateSlot(Slot slot, Transform slotsGrid)
        {
            SlotView slotView = InstantiateSlot(slot, slotsGrid);
            InitSlotActor(slot, slotView);
            return slotView;
        }

        public GameObject CreateItem(LootId lootId, SlotView slotView, SlotActor slotActor)
        {
            RectTransform itemView = InstantiateItem(lootId, slotView.ItemHolder);
            InitDraggableItem(itemView, slotActor);
            SetItemSize(itemView, slotView.transform);
            return itemView.gameObject;
        }
    
        private SlotView InstantiateSlot(Slot slot, Transform slotsGrid)
        {
            string slotPath = slot.IsHotSlot 
                ? AssetPath.HotSlotPath 
                : AssetPath.SlotPath;
            
            var slotView = _assetProvider.Instantiate<SlotView>(slotPath, slotsGrid);
            return slotView;
        }

        private static void InitSlotActor(Slot slot, SlotView slotView)
        {
            var slotActor = new SlotActor(slot, slotView);
            slotView.Init(slotActor);
        }

        private RectTransform InstantiateItem(LootId lootId, Transform slot)
        {
            LootData lootData = _staticDataService.GetLootData(lootId);
            var itemView = _assetProvider.Instantiate<RectTransform>(lootData.IconPath, slot);
            return itemView;
        }

        private void InitDraggableItem(RectTransform itemView, SlotActor slotActor) 
            => itemView
                .GetComponent<DraggableItem>()
                .Init(_objectsProvider.HudCanvas, slotActor);

        private static void SetItemSize(RectTransform itemIcon, Transform slot)
        {
            Vector2 scaleFactor = ((RectTransform)slot).rect.size / itemIcon.rect.size;
            Vector3 itemScale = itemIcon.localScale;
            itemScale = new Vector3(itemScale.x * scaleFactor.x, itemScale.y * scaleFactor.y, itemScale.z);
            itemIcon.localScale = itemScale;
        }
    }
}
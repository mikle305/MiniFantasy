using Additional.Extensions;
using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using Infrastructure.Services;
using StaticData;
using TMPro;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace UI.InventorySystem
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Transform _itemHolder;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _countText;

        private SlotActor _slotActor;
        private IInventoryUiFactory _inventoryUiFactory;
        private IStaticDataService _staticDataService;
        private HudConfiguration _hudConfig;
        
        private LootId _currentItemId = LootId.None;
        private int _currentCount;
        private GameObject _icon;

        public Transform ItemHolder => _itemHolder;

        public SlotActor Actor => _slotActor;


        [Inject]
        public void Construct(IInventoryUiFactory inventoryUiFactory, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _inventoryUiFactory = inventoryUiFactory;
        }
        
        public void Init(SlotActor slotActor)
        {
            _slotActor = slotActor;
            _hudConfig = _staticDataService.GetHudConfig();
        }

        public void UpdateItemInfo(LootId lootId, int count)
        {
            if (lootId != LootId.None)
                ShowItemInfo(lootId, count);
            else
                HideItemInfo();
        }

        public void DestroyIcon()
        {
            if (_icon != null)
                Destroy(_icon);
        }

        private void ShowItemInfo(LootId lootId, int count)
        {
            var lootData = _staticDataService.GetLootData<InventoryLootData>(lootId);
            ShowCount(count);

            if (lootId == _currentItemId)
                return;

            ShowIcon(lootId);
            ShowName(lootData.Name);
            ShowRarity(lootData.ItemRarity);
            _currentItemId = lootId;
        }

        private void HideItemInfo()
        {
            _currentItemId = LootId.None;
            _countText.text = string.Empty;
            _nameText.text = string.Empty;
        }
        

        private void ShowName(string itemName)
        {
            _nameText.text = (itemName ?? string.Empty)
                .SplitByCapital()
                .ConvertToString(" ");
        }

        private void ShowIcon(LootId lootId) 
            => _icon = _inventoryUiFactory.CreateItem(lootId, this, Actor);

        private void ShowCount(int itemCount) 
            => _countText.text = itemCount != 0 
                ? $"x{itemCount}"
                : string.Empty;

        private void ShowRarity(ItemRarity itemRarity)
        {
            if (!_hudConfig.ItemRarityColorMap.TryGetValue(itemRarity, out Color rarityColor))
                rarityColor = Color.white;

            _nameText.color = rarityColor;
        }
    }
}
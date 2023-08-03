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
        private IUiFactory _uiFactory;
        private IStaticDataService _staticDataService;
        private HudConfiguration _hudConfig;

        private GameObject _itemIcon;
        private LootId _currentItemId = LootId.None;


        [Inject]
        public void Construct(IUiFactory uiFactory, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
        }
        
        public void Init(SlotActor slotActor)
        {
            _slotActor = slotActor;
            _slotActor.Subscribe();
            
            _hudConfig = _staticDataService.GetHudConfig();
        }

        public void UpdateItemInfo(LootId lootId, int count)
        {
            var lootData = _staticDataService.GetLootData<InventoryLootData>(lootId);
            ShowCount(count);
            
            if (lootId == _currentItemId)
                return;

            _currentItemId = lootId;
            ShowIcon(lootId);
            ShowName(lootData.Name);
            ShowRarity(lootData.ItemRarity);
        }

        private void ShowIcon(LootId lootId)
        {
            _itemIcon = _uiFactory.CreateItem(lootId, _itemHolder);
        }

        private void ShowName(string itemName)
        {
            _nameText.text = (itemName ?? string.Empty)
                .SplitByCapital()
                .ConvertToString(" ");
        }

        private void ShowCount(int itemCount)
        {
            _countText.text = itemCount.ToString();
        }

        private void ShowRarity(ItemRarity itemRarity)
        {
            if (!_hudConfig.ItemRarityColorMap.TryGetValue(itemRarity, out Color rarityColor))
                rarityColor = Color.white;

            _nameText.color = rarityColor;
        }
    }
}
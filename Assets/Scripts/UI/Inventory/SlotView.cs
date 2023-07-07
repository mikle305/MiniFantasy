using GamePlay.InventorySystem;
using GamePlay.LootSystem;
using Infrastructure.Services;
using TMPro;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace UI.Inventory
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Transform _itemHolder;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _countText;

        private ItemView _itemView;
        private SlotActor _slotActor;
        private IUiFactory _uiFactory;
        private IUiConfigurator _uiConfigurator;


        [Inject]
        public void Construct(IUiFactory uiFactory, IUiConfigurator uiConfigurator)
        {
            _uiFactory = uiFactory;
            _uiConfigurator = uiConfigurator;
        }
        
        public void Init(Slot slot)
        {
            _slotActor = new SlotActor(slot, this);
            _slotActor.Subscribe();
        }

        public void UpdateItemInfo(LootId lootId, int count)
        {
            _itemView = _uiFactory.CreateItem(lootId, _itemHolder);
            _itemView.Init(_nameText, _countText);
            _uiConfigurator.ConfigureInventoryItem(_itemView, lootId, count);
        }
    }
}
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
        
        public void Init(SlotActor slotActor)
        {
            _slotActor = slotActor;
            _slotActor.Subscribe();
        }

        public void UpdateItemInfo(LootId lootId, int count)
        {
            _itemView = CreateItemView(lootId);
            _itemView.ShowCount(count);
        }

        private ItemView CreateItemView(LootId lootId)
        {
            ItemView itemView = _uiFactory.CreateItem(lootId, _itemHolder);
            itemView.InitComponents(_nameText, _countText);
            _uiConfigurator.ConfigureItemView(itemView, lootId);
            return itemView;
        }
    }
}
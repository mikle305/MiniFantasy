using GamePlay.InventorySystem;
using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _slotsGrid;
        
        private InventoryActor _inventoryActor;
        private IUiFactory _uiFactory;


        [Inject]
        public void Construct(IUiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void Init(InventoryActor inventoryActor)
        {
            _inventoryActor = inventoryActor;
            _inventoryActor.Subscribe();
        }

        public void ToggleWindow()
            => gameObject.SetActive(!gameObject.activeSelf);

        public void AddSlots(Slot[] slots)
        {
            foreach (Transform slot in _slotsGrid)
                Destroy(slot.gameObject);
                
            foreach (Slot slot in slots) 
                _uiFactory.CreateSlot(slot, _slotsGrid);
        }
    }
}
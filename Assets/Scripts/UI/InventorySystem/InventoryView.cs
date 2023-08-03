using GamePlay.InventorySystem;
using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace UI.InventorySystem
{

    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _slotsGrid;
        
        private InventoryActor _inventoryActor;
        protected IUiFactory _uiFactory;


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

        public virtual void ShowSlots(Slot[] slots)
        {
            foreach (Slot slot in slots) 
                _uiFactory.CreateSlot(slot, _slotsGrid);
        }
    }
}
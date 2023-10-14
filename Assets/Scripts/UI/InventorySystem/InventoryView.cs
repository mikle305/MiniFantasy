using System.Collections.Generic;
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
        private IInventoryUiFactory _inventoryUiFactory;


        [Inject]
        public void Construct(IInventoryUiFactory inventoryUiFactory)
        {
            _inventoryUiFactory = inventoryUiFactory;
        }
        
        public void Init(InventoryActor inventoryActor)
        {
            _inventoryActor = inventoryActor;
        }

        public void ToggleWindow()
            => gameObject.SetActive(!gameObject.activeSelf);

        public virtual void ShowSlots(Slot[] slots)
        {
            CreateSlots(slots, _slotsGrid);
        }

        protected void CreateSlots(IEnumerable<Slot> slots, Transform slotsGrid)
        {
            foreach (Slot slot in slots)
                _inventoryUiFactory.CreateSlot(slot, slotsGrid);

            /*slotsGrid
                .GetComponent<GridLayoutGroup>()
                .enabled = false;*/
        }
    }
}
using UI.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ToggleInventoryButton : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventory;
        
        private Button _button;

        
        private void Start()
        {
            _inventory = FindObjectOfType<InventoryView>(true);
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ToggleInventory);
        }

        private void ToggleInventory()
            => _inventory.ToggleWindow();
    }
}
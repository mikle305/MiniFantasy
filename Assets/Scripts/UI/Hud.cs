using UI.Inventory;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class Hud : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private HudStatBar _healthBar;
        [SerializeField] private InventoryView _inventoryView;


        public Canvas Canvas => _canvas;
        public HudStatBar HealthBar => _healthBar;
        public InventoryView InventoryView => _inventoryView;
    }
}
using UI.Inventory;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class Hud : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private HudStatBar _healthBar;
        [SerializeField] private CharacterInventoryView _inventoryView;


        public Canvas Canvas => _canvas;
        public HudStatBar HealthBar => _healthBar;
        public CharacterInventoryView InventoryView => _inventoryView;
    }
}
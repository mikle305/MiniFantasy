using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class Hud : MonoBehaviour
    {
        [SerializeField] private HudStatBar _healthBar;

        
        public HudStatBar HealthBar => _healthBar;
    }
}
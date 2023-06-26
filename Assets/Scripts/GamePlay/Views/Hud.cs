using UI;
using UnityEngine;

namespace GamePlay.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class Hud : MonoBehaviour
    {
        [SerializeField] private HudActor _hudActor;
        [SerializeField] private StatBar _healthBar;

        public RectTransform RectTransform { get; private set; }

        public HudActor HudActor => _hudActor;
        
        public StatBar HealthBar => _healthBar;
        
        
        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }
}
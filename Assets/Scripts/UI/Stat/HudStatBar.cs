using GamePlay.Units;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class HudStatBar : MonoBehaviour, IStatBar
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void Init(ICharacteristic health)
        { 
            var actor = new StatActor(health, this);
            actor.Subscribe();
        }

        public void SetValue(float current, float max)
            => _slider.value = current / max;
    }
}

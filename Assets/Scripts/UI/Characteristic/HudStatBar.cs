using GamePlay.Units;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class HudStatBar : MonoBehaviour, IStatBar
    {
        private Slider _slider;
        private StatActor _statActor;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void Init(StatActor statActor)
        {
            _statActor = statActor;
            _statActor.Subscribe();
        }

        public void SetValue(float current, float max)
            => _slider.value = current / max;
    }
}

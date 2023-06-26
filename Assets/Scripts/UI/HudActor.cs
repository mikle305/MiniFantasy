using GamePlay.Units.Health;
using UnityEngine;

namespace UI
{
    public class HudActor : MonoBehaviour
    {
        private StatBar _healthBar;
        private IHealth _health;

        public void InitHealth(IHealth health, StatBar healthBar)
        {
            _health = health;
            _healthBar = healthBar;
            
            _health.Changed += UpdateHealthBar;
            UpdateHealthBar();
        }

        private void OnDestroy()
        {
            _health.Changed -= UpdateHealthBar;
        }

        private void UpdateHealthBar() 
            => _healthBar.SetValue(_health.CurrentValue, _health.MaxValue);
    }
}
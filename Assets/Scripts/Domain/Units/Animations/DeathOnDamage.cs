using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Specific.Enemy
{
    [RequireComponent(typeof(IDieAnimator))]
    [RequireComponent(typeof(IDamageable))]
    public class DeathOnDamage : MonoBehaviour
    {
        [SerializeField] private float _animDuration = 2;
        [SerializeField] private float _destroyDuration = 10;
        
        private IDieAnimator _dieAnimator;
        private IDamageable _damageable;


        private void Awake()
        {
            _dieAnimator = GetComponent<IDieAnimator>();
            _damageable = GetComponent<IDamageable>();

            _damageable.ZeroReached += Die;
            _dieAnimator.SetDieDuration(_animDuration);
        }

        private void Die()
        {
            _dieAnimator.PlayDie();
            float destroyDelay = _destroyDuration > _animDuration ? _destroyDuration : _animDuration;
            Destroy(gameObject, destroyDelay);
        }
    }
}
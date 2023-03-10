using System.Collections;
using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Specific.Enemy
{
    [RequireComponent(typeof(IDamageable))]
    [RequireComponent(typeof(IDieAnimator))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private float _animDuration;
        [SerializeField] private float _destroyDuration;

        private IDamageable _damageable;
        private IDieAnimator _dieAnimator;


        private void Awake()
        {
            _damageable = GetComponent<IDamageable>();
            _dieAnimator = GetComponent<IDieAnimator>();

            _damageable.Damaged += OnDamaged;
        }

        private void OnDamaged(float health)
        {
            if (health > 0)
                return;
            
            _dieAnimator.PlayDie();
            StartCoroutine(Destroy(_destroyDuration));
        }

        private IEnumerator Destroy(float duration)
        {
            yield return new WaitForSeconds(duration);

            Destroy(gameObject);
        }
    }
}
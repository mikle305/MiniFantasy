using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Animations
{
    [RequireComponent(typeof(IDieAnimator))]
    [RequireComponent(typeof(IHealth))]
    public class DeathOnDamage : MonoBehaviour
    {
        [SerializeField] private float _animDuration = 2;
        [SerializeField] private float _destroyDuration = 10;
        [Tooltip("Not required")][SerializeField] private Effect _effect;

        private IHealth _health;
        private IDieAnimator _animator;
        private Collider[] _colliders;


        private void Awake()
        {
            _animator = GetComponent<IDieAnimator>();
            _health = GetComponent<IHealth>();
            _colliders = GetComponents<Collider>();

            _animator.SetDieDuration(_animDuration);
            _health.ZeroReached += Die;
        }

        private void Die()
        {
            _animator.PlayDie();
            Invoke(nameof(OnAnimated), _animDuration);
            Invoke(nameof(OnDestroyed), _destroyDuration);
        }

        protected virtual void OnAnimated()
        {
            DisableColliders();
            PlayEffect();
        }

        protected virtual void OnDestroyed()
        {
            Destroy(gameObject);
        }

        private void DisableColliders()
        {
            foreach (Collider col in _colliders)
            {
                col.enabled = false;
            }
        }

        private void PlayEffect()
        {
            if (_effect != null)
                _effect.Play();
        }
    }
}
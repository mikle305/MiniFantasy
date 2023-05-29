using Additional.Utils;
using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using StaticData;
using UnityEngine;

namespace Domain.Units.Animations
{
    public class DeathOnDamage : MonoBehaviour
    {
        private float _animDuration;
        private float _destroyDuration;
        private Effect _effect;

        private IHealth _health;
        private IDieAnimator _animator;
        private Collider[] _colliders;


        public void Init(float animDuration, float destroyDuration, Effect effect = null)
        {
            _animDuration = animDuration;
            _destroyDuration = destroyDuration;
            _effect = effect;
            
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

        protected void OnAnimated()
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
                col.enabled = false;
        }

        private void PlayEffect() 
            => GameUtils.PlayEffect(_effect, transform);
    }
}
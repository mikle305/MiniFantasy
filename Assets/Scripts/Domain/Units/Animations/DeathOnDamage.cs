using System;
using System.Collections;
using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Animations
{
    [RequireComponent(typeof(IDamageable))]
    public class DeathOnDamage : MonoBehaviour
    {
        [Tooltip("Will be used only if object has death animator")][SerializeField] private float _animDuration = 2;
        [SerializeField] private float _destroyDuration = 10;
        [Tooltip("Not required")][SerializeField] private GameObject _effect;

        private IDamageable _damageable;
        private IDieAnimator _dieAnimator;


        private void Awake()
        {
            _dieAnimator = GetComponent<IDieAnimator>();
            _damageable = GetComponent<IDamageable>();

            _damageable.ZeroReached += Die;
            _dieAnimator.SetDieDuration(_animDuration);
        }

        private void Die()
        {
            PlayAnim();
            Invoke(nameof(OnAnimated), _animDuration);
        }
        
        private void OnAnimated()
        {
            float destroyDelay = _destroyDuration > 0 ? _destroyDuration : 0;
            PlayFx();
            Destroy(gameObject, destroyDelay);
        }

        private void PlayAnim()
        {
            if (_dieAnimator != null)
                _dieAnimator.PlayDie();
            else
                _animDuration = 0;
        }

        private void PlayFx()
        {
            if (_effect != null)
                Instantiate(_effect, transform.position, Quaternion.identity);
        }
    }
}
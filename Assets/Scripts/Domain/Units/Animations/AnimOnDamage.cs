using System;
using System.Collections;
using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Animations
{
    [RequireComponent(typeof(IHitAnimator))]
    [RequireComponent(typeof(IDamageable))]
    public class AnimOnDamage : MonoBehaviour
    {
        [SerializeField] private float _hitDuration;

        private IDamageable _damageable;
        private IHitAnimator _animator;
        
        private Coroutine _endedCoroutine;
        
        public event Action Started;
        public event Action Ended;


        private void Awake()
        {
            _damageable = GetComponent<IDamageable>();
            _animator = GetComponent<IHitAnimator>();
            
            _animator.SetHitDuration(_hitDuration);
            _damageable.Damaged += AnimateHit;
        }

        private void AnimateHit(float health)
        {

            if (_endedCoroutine != null)
                StopCoroutine(_endedCoroutine);

            Started?.Invoke();
            _animator.PlayHit();
            _endedCoroutine = StartEndedCoroutine();
        }

        private Coroutine StartEndedCoroutine() 
            => StartCoroutine(InvokeDamageEnded(_hitDuration));

        private IEnumerator InvokeDamageEnded(float delay)
        {
            yield return new WaitForSeconds(delay);

            Ended?.Invoke();
        }
    }
}
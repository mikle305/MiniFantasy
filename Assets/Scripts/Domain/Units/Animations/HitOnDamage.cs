using System;
using System.Collections;
using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using UnityEngine;

namespace Domain.Units.Animations
{
    [RequireComponent(typeof(IHitAnimator))]
    [RequireComponent(typeof(IHealth))]
    public class HitOnDamage : MonoBehaviour
    {
        [SerializeField] private float _hitDuration;

        private IHealth _health;
        private IHitAnimator _animator;
        
        private Coroutine _endedCoroutine;
        
        public event Action Started;
        public event Action Ended;


        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _animator = GetComponent<IHitAnimator>();
            
            _animator.SetHitDuration(_hitDuration);
            _health.Changed += AnimateHit;
        }

        private void AnimateHit()
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
using System;
using System.Collections;
using Domain.Units.AnimatorAbstractions;
using UnityEngine;

namespace Domain.Units.Health
{
    [RequireComponent(typeof(IHitAnimator))]
    [RequireComponent(typeof(Health))]
    public class HitAnimOnHealth : MonoBehaviour
    {
        private const float _hitDuration = 1.0f;
        private Health _health;
        private IHitAnimator _animator;

        public event Action Started;
        public event Action Ended;

        
        private void Awake()
        {
            _health = GetComponent<Health>();
            _animator = GetComponent<IHitAnimator>();
            
            _animator.SetHitDuration(_hitDuration);
            _health.Damaged += AnimateHit;
        }

        private void AnimateHit()
        {
            Started?.Invoke();
            _animator.PlayHit();
            StartCoroutine(InvokeDamageEnded(_hitDuration));
        }

        private IEnumerator InvokeDamageEnded(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            Ended?.Invoke();
        }
    }
}
using System;
using System.Collections;
using Domain.Units.Animations.Abstractions;
using Domain.Units.Health;
using StaticData;
using UnityEngine;

namespace Domain.Units.Animations
{
    public class HitOnDamage : MonoBehaviour
    {
        private float _animDuration;

        private IHealth _health;
        private IHitAnimator _animator;
        
        private Coroutine _endedCoroutine;
        
        public event Action Started;
        public event Action Ended;
        
        
        public void Init(float animDuration, Effect effect = null)
        {
            _animDuration = animDuration;
            _animator = GetComponent<IHitAnimator>();
            _animator.SetHitDuration(_animDuration);
            _health = GetComponent<IHealth>();
            _health.Changed += AnimateHit;
        }

        private void AnimateHit()
        {
            Started?.Invoke();
            _animator.PlayHit();
            if (_endedCoroutine != null)
                StopCoroutine(_endedCoroutine);
            
            _endedCoroutine = StartCoroutine(InvokeDamageEnded(_animDuration));
        }

        private IEnumerator InvokeDamageEnded(float delay)
        {
            yield return new WaitForSeconds(delay);

            Ended?.Invoke();
        }
    }
}
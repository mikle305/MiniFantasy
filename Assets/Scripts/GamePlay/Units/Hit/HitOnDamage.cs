﻿using System;
using System.Collections;
using UnityEngine;

namespace GamePlay.Units.Hit
{
    public class HitOnDamage : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private IHitAnimator _animator;
        private float _animDuration;
        private Coroutine _endedCoroutine;
        
        public event Action Started;
        public event Action Ended;
        
        
        public void Init(float animDuration)
        {
            _animator = GetComponentInParent<IHitAnimator>() ?? GetComponent<IHitAnimator>();
            
            _animDuration = animDuration;
            _animator.SetHitDuration(_animDuration);
            _health.ValueChanged += AnimateHit;
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
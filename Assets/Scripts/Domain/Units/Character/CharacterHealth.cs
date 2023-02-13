using System;
using System.Collections;
using Domain.Units.Stats.Components;
using UnityEngine;

namespace Domain.Units.Character
{
    [RequireComponent(typeof(CharacterAnimator))]
    public class CharacterHealth : Health
    {
        [SerializeField] private CharacterAnimator _characterAnimator;
        [SerializeField] private float _hitDuration = 1.0f;

        public event Action DamageStarted;
        public event Action DamageEnded;

        
        private void Awake()
        {
            _characterAnimator.SetGetHitDuration(_hitDuration);
        }

        public override void TakeDamage(float value)
        {
            base.TakeDamage(value);
            
            DamageStarted?.Invoke();
            _characterAnimator.PlayHit();
            StartCoroutine(InvokeDamageEnded(_hitDuration));
        }

        private IEnumerator InvokeDamageEnded(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            DamageEnded?.Invoke();
        }
    }
}
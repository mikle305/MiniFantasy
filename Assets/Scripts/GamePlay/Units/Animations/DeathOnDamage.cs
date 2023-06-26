using System;
using System.Collections;
using GamePlay.Units.Health;
using UnityEngine;

namespace GamePlay.Units.Animations
{
    public class DeathOnDamage : MonoBehaviour
    {
        private IHealth _health;
        private IDieAnimator _animator;
        private float _animDuration;

        public event Action Happened;

        
        public void Init(float animDuration)
        {
            _animator = GetComponent<IDieAnimator>();
            _health = GetComponent<IHealth>();
            _animDuration = animDuration;
            _health.ZeroReached += Die;
        }

        private void Die() 
            => StartCoroutine(DieCoroutine());

        private IEnumerator DieCoroutine()
        {
            _animator.SetDieDuration(_animDuration);
            _animator.PlayDie();
            
            yield return new WaitForSeconds(_animDuration);
            
            Happened?.Invoke();
        }
    }
}
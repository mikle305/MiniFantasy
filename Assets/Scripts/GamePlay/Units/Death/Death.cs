using System;
using System.Collections;
using UnityEngine;

namespace GamePlay.Units.Death
{
    public class Death : MonoBehaviour
    {
        private IDieAnimator _animator;
        private float _animDuration;

        public event Action Happened;

        
        public void Init(float animDuration)
        {
            _animator = GetComponentInParent<IDieAnimator>() ?? GetComponent<IDieAnimator>();
            _animDuration = animDuration;
        }

        public void Die() 
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
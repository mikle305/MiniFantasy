using System;
using System.Collections;
using UnityEngine;

namespace Domain.Character
{
    public class CharacterAttacker : MonoBehaviour
    {
        [SerializeField] private float _attackDuration = 2.0f;

        private CharacterAnimator _characterAnimator;


        public event Action AttackStarted;
        
        public event Action AttackEnded;


        public void Attack()
        {
            AttackStarted?.Invoke();
            
            _characterAnimator.PlayMeleeAttack();
            
            StartCoroutine(InvokeAttackEnded(_attackDuration));
        }

        private void Awake()
        {
            _characterAnimator = GetComponent<CharacterAnimator>();
            _characterAnimator.SetAttackDuration(_attackDuration);
        }

        private IEnumerator InvokeAttackEnded(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            AttackEnded?.Invoke();
        }
    }
}
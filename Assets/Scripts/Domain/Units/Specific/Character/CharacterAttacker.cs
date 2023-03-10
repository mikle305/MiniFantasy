﻿using System;
using System.Collections;
using System.Linq;
using Additional.Extensions;
using Additional.Utils;
using Domain.Units.Animations.Abstractions;
using Domain.Units.Stats;
using UnityEngine;

namespace Domain.Units.Specific.Character
{
    [RequireComponent(typeof(CharacterAnimator))]
    [RequireComponent(typeof(CharacterController))]
    public class CharacterAttacker : MonoBehaviour
    {
        [Header("Hits settings")] [Space(3)] 
        [SerializeField] private float _hitRadius;
        [SerializeField] private float _hitDistance;
        [SerializeField] private int _maxHitsCount = 1;
        [SerializeField] private int _layerId;

        private IAttackAnimator _characterAnimator;
        private Collider[] _hits;
        private float _bodyMid;
        private int _layerMask;
        
        private const float _attackDuration = 2.0f;
        private const float _firstAttackDamage = 1.0f;
        private const float _secondAttackDamage = 0.5f;

        public event Action AttackStarted;
        public event Action AttackEnded;


        private void Awake()
        {
            _characterAnimator = GetComponent<IAttackAnimator>();
            var characterController = GetComponent<CharacterController>();
            
            _characterAnimator.SetAttackDuration(_attackDuration);
            
            _layerMask = 1 << _layerId;
            _bodyMid = characterController.height / 2;
            _hits = new Collider[_maxHitsCount];
        }

        public void Attack()
        {
            AttackStarted?.Invoke();
            _characterAnimator.PlayMeleeAttack();
            StartCoroutine(InvokeAttackEnded(_attackDuration));
        }

        // Animation event callback
        private void OnFirstAttackAnimated()
        {
            PhysicsDebug.DrawSphere(CalculateHitPoint(), _hitRadius);

            TryDamage(_firstAttackDamage);
        }
        
        // Animation event callback
        private void OnSecondAttackAnimated()
        {
            PhysicsDebug.DrawSphere(CalculateHitPoint(), _hitRadius);

            TryDamage(_secondAttackDamage);
        }

        private bool TryDamage(float damage)
        {
            if (!TryHit(out Collider hit))
                return false;
            
            if (!hit.TryGetComponent(out Health health))
                return false;
            
            health.TakeDamage(damage);
            return true;
        }
        
        private bool TryHit(out Collider hit)
        {
            int hitsCount = Physics.OverlapSphereNonAlloc(
                CalculateHitPoint(), 
                _hitRadius, 
                _hits, 
                _layerMask);
            
            hit = _hits.FirstOrDefault();
            
            return hitsCount > 0;
        }

        private Vector3 CalculateHitPoint()
        {
            Transform t = transform;
            return t.position.AddY(_bodyMid) + t.forward * _hitDistance;
        }

        private IEnumerator InvokeAttackEnded(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            AttackEnded?.Invoke();
        }
    }
}
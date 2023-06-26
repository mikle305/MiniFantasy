﻿using DiContainer.UniDependencyInjection.Core.Unity;
using GamePlay.Units.Animations;
using GamePlay.Units.Health;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class CharacterState : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterAttacker _characterAttacker;
        private HitOnDamage _hitOnDamage;
        private IHealth _health;
        private IInputService _inputService;

        private bool _isAttacking;
        private bool _isHited;
        private bool _isDied;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Awake()
        {
            InitDependencies();
            InitStatesUpdaters();
        }

        private void Update()
        {
            if (_isAttacking || _isDied || _isHited)
                return;
            
            if (_inputService.IsAttackInvoked() && !_inputService.IsUiPressed())
            {
                _characterAttacker.Attack();
                return;
            }
            
            Vector2 axis = _inputService.GetAxis();
            _characterMovement.Move(axis);
        }

        private void InitDependencies()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _characterAttacker = GetComponent<CharacterAttacker>();
            _hitOnDamage = GetComponent<HitOnDamage>();
            _health = GetComponent<IHealth>();
        }

        private void InitStatesUpdaters()
        {
            _characterAttacker.AttackStarted +=
                () => _isAttacking = true;

            _characterAttacker.AttackEnded +=
                () => _isAttacking = false;

            _hitOnDamage.Started +=
                () => _isHited = true;

            _hitOnDamage.Ended +=
                () => _isHited = false;

            _health.ZeroReached +=
                () => _isDied = true;
        }
    }
}
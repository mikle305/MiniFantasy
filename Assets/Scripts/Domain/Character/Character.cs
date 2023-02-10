using System.Collections;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Domain.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterAttacker))]
    [RequireComponent(typeof(CharacterAnimator))]
    public class Character : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterAttacker _characterAttacker;
        private CharacterAnimator _characterAnimator;
        private IInputService _inputService;

        private float _attackDuration;
        private bool _isAttacking;

        private void Awake()
        {
            ServiceProvider services = ServiceProvider.Container;
            _inputService = services.Resolve<IInputService>();

            _characterMovement = GetComponent<CharacterMovement>();
            _characterAttacker = GetComponent<CharacterAttacker>();
            _characterAnimator = GetComponent<CharacterAnimator>();
        }
        
        private void Start()
        {
            _attackDuration = _characterAttacker.AttackDuration;
            _characterAnimator.SetAttackDuration(_attackDuration);
        }

        private void Update()
        {
            if (_isAttacking)
                return;
            
            if (_inputService.IsAttackInvoked())
            {
                _isAttacking = true;
                _characterAnimator.PlayMeleeAttack();
                StartCoroutine(StopAttacking(_attackDuration));
                return;
            }
            
            Vector2 axis = _inputService.GetAxis();
            bool isMoved = _characterMovement.Move(axis);
            
            if (isMoved)
                _characterAnimator.UpdateMoving(1);
            else
                _characterAnimator.StopMoving();
        }

        private IEnumerator StopAttacking(float delay)
        {
            yield return new WaitForSeconds(delay);

            _isAttacking = false;
        }
    }
}
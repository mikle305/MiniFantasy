using Infrastructure.Services;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Domain.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterAttacker))]
    public class Character : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterAttacker _characterAttacker;
        private IInputService _inputService;

        private float _attackDuration;
        private bool _isAttacking;

        
        private void Awake()
        {
            ServiceProvider services = ServiceProvider.Container;
            _inputService = services.Resolve<IInputService>();

            _characterMovement = GetComponent<CharacterMovement>();
            _characterAttacker = GetComponent<CharacterAttacker>();
        }

        private void Start()
        {
            _characterAttacker.AttackStarted += 
                () => _isAttacking = true;

            _characterAttacker.AttackEnded +=
                () => _isAttacking = false;
        }

        private void Update()
        {
            ActOnInput();
        }

        private void ActOnInput()
        {
            if (_isAttacking)
                return;

            if (_inputService.IsAttackInvoked())
            {
                _characterAttacker.Attack();
                return;
            }

            Vector2 axis = _inputService.GetAxis();
            _characterMovement.UpdateMoving(axis);
        }
    }
}
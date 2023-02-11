using Infrastructure.Services;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Domain.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterAttacker))]
    public class CharacterActor : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterAttacker _characterAttacker;
        private IInputService _inputService;
        
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
                Attack();
                return;
            }

            Move(_inputService.GetAxis());
        }

        private void Attack() 
            => _characterAttacker.Attack();

        private void Move(Vector2 axis) 
            => _characterMovement.Move(axis);
    }
}
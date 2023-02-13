using Infrastructure.Services;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Domain.Units.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterAttacker))]
    public class CharacterActor : MonoBehaviour
    {
        [SerializeField] private CharacterHealth _characterHealth;
        
        private CharacterMovement _characterMovement;
        private CharacterAttacker _characterAttacker;
        private IInputService _inputService;
        
        private bool _isAttacking;
        private bool _isHited;
        

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

            _characterHealth.DamageStarted +=
                () => _isHited = true;

            _characterHealth.DamageEnded +=
                () => _isHited = false;
        }

        private void Update()
        {
            ActOnInput();
        }

        private void ActOnInput()
        {
            if (_isAttacking)
                return;
            
            if (_isHited)
                return;

            if (_inputService.IsAttackInvoked() && !_inputService.IsUiPressed())
            {
                _characterAttacker.Attack();
                return;
            }
            
            Vector2 axis = _inputService.GetAxis();
            _characterMovement.Move(axis);
        }
    }
}
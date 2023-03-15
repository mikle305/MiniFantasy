using Domain.Units.Animations;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Domain.Units.Specific.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    [RequireComponent(typeof(CharacterAttacker))]
    [RequireComponent(typeof(HitOnDamage))]
    public class CharacterState : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterAttacker _characterAttacker;
        private HitOnDamage _hitOnDamage;
        private IInputService _inputService;
        
        private bool _isAttacking;
        private bool _isHited;
        

        private void Awake()
        {
            InitDependencies();
            InitStatesUpdaters();
        }

        private void Update()
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
        }

        private void InitDependencies()
        {
            ServiceProvider services = ServiceProvider.Container;
            _inputService = services.Resolve<IInputService>();

            _characterMovement = GetComponent<CharacterMovement>();
            _characterAttacker = GetComponent<CharacterAttacker>();
            _hitOnDamage = GetComponent<HitOnDamage>();
        }
    }
}
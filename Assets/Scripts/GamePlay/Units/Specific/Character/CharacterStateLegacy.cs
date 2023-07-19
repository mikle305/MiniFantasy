using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.Units
{
    public class CharacterStateLegacy : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterAttacker _characterAttacker;
        private HitOnDamage _hitOnDamage;
        private Health _health;
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
            
            if (_inputService.IsAttackInvoked())
            {
                _characterAttacker.Attack();
                return;
            }
            
            Vector2 axis = _inputService.GetAxis();
            Vector3 cameraDirection = _inputService.GetCameraDirection();
            _characterMovement.Move(axis, cameraDirection);
        }

        private void InitDependencies()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _characterAttacker = GetComponent<CharacterAttacker>();
            _hitOnDamage = GetComponent<HitOnDamage>();
            _health = GetComponent<Health>();
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
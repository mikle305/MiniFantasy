using UnityEngine;

namespace Domain.Character
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimator : MonoBehaviour, ICharacterAnimator
    {
        private static readonly int _dieHash = Animator.StringToHash("Die");
        private static readonly int _getHitHash = Animator.StringToHash("GetHit");
        private static readonly int _meleeAttackHash = Animator.StringToHash("MeleeAttack");
        private static readonly int _speedHash = Animator.StringToHash("Speed");
        private static readonly int _isMovingHash = Animator.StringToHash("IsMoving");

        private Animator _animator;

        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayMeleeAttack() =>
            _animator.SetTrigger(_meleeAttackHash);

        public void PlayHit() =>
            _animator.SetTrigger(_getHitHash);

        public void PlayDie() =>
            _animator.SetTrigger(_dieHash);

        public void UpdateMoving(float speedCoefficient)
        {
            _animator.SetBool(_isMovingHash, true);
            _animator.SetFloat(_speedHash, speedCoefficient);
        }

        public void StopMoving() =>
            _animator.SetBool(_isMovingHash, false);
    }
}
using UnityEngine;

namespace Domain.Enemies.Ninja
{
    [RequireComponent(typeof(Animator))]
    public class NinjaAnimator : MonoBehaviour, INinjaAnimator
    {
        // Parameters
        private static readonly int _dieHash = Animator.StringToHash("Die");
        private static readonly int _getHitHash = Animator.StringToHash("GetHit");
        private static readonly int _meleeAttackHash = Animator.StringToHash("MeleeAttack");
        private static readonly int _speedHash = Animator.StringToHash("Speed");
        private static readonly int _isMovingHash = Animator.StringToHash("IsMoving");
        private static readonly int _attackSpeedHash = Animator.StringToHash("AttackSpeed");

        private Animator _animator;

        // Clips names
        private const string _meleeAttackClipName = "RotateAndAttack";

        // Clips lengths
        private float _meleeAttackClipLength;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            InitClipsLengths();
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

        public void SetAttackDuration(float duration)
        {
            float multiplier = _meleeAttackClipLength / duration;
            _animator.SetFloat(_attackSpeedHash, multiplier);
        }

        private void InitClipsLengths()
        {
            AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;
            
            foreach(AnimationClip clip in clips)
            {
                switch(clip.name)
                {
                    case _meleeAttackClipName:
                        _meleeAttackClipLength = clip.length;
                        break;
                }
            }
        }
    }
}
using Domain.Units.Animations.Abstractions;
using UnityEngine;

namespace Domain.Units.Specific.Enemy
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : UnitAnimator, IMoveAnimator, IHitAnimator, IAttackAnimator, IDieAnimator
    {
        [Header("Clips names")] [Space(3)]
        [SerializeField] private string _meleeAttackClipName = "RotateAndAttack";
        [SerializeField] private string _getHitClipName = "GettingHit";
        [SerializeField] private string _dieClipName = "StandingDeathBackward";

        // Parameters
        private static readonly int _dieHash = Animator.StringToHash("Die");
        private static readonly int _getHitHash = Animator.StringToHash("GetHit");
        private static readonly int _meleeAttackHash = Animator.StringToHash("MeleeAttack");
        private static readonly int _speedHash = Animator.StringToHash("Speed");
        private static readonly int _isMovingHash = Animator.StringToHash("IsMoving");

        // Clips lengths
        private float _meleeAttackClipLength;
        private float _getHitClipLength;
        private float _dieClipLength;

        // Anim states speed multipliers
        private static readonly int _attackSpeedHash = Animator.StringToHash("AttackSpeed");
        private static readonly int _getHitSpeedHash = Animator.StringToHash("GetHitSpeed");
        private static readonly int _dieSpeedHash = Animator.StringToHash("DieSpeed");


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

        
        public void SetAttackDuration(float duration) => 
            SetAnimStateDuration(_attackSpeedHash, _meleeAttackClipLength, duration);

        public void SetHitDuration(float duration) => 
            SetAnimStateDuration(_getHitSpeedHash, _getHitClipLength, duration);

        public void SetDieDuration(float duration) => 
            SetAnimStateDuration(_dieSpeedHash, _dieClipLength, duration);


        protected override void InitClipsLengths()
        {
            AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;
            
            foreach(AnimationClip clip in clips)
            {
                switch(clip.name)
                {
                    case var value when value == _meleeAttackClipName:
                        _meleeAttackClipLength = clip.length;
                        break;
                    case var value when value == _getHitClipName:
                        _getHitClipLength = clip.length;
                        break;
                    case var value when value == _dieClipName:
                        _dieClipLength = clip.length;
                        break;
                }
            }
        }
    }
}
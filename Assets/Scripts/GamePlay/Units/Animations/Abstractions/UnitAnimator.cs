using UnityEngine;

namespace GamePlay.Units.Animations
{
    [RequireComponent(typeof(Animator))]
    public abstract class UnitAnimator : MonoBehaviour
    {
        protected Animator _animator;


        protected void Awake()
        {
            _animator = GetComponent<Animator>();
            InitClipsLengths();
        }
        
        protected void SetAnimStateDuration(int paramHash, float clipLength, float duration)
        {
            float multiplier = clipLength / duration;
            _animator.SetFloat(paramHash, multiplier);
        }

        protected abstract void InitClipsLengths();
    }
}
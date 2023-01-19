using UnityEngine;

namespace Domain.Character
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation: MonoBehaviour
    {
        private Animator _animator;
        private CharacterAnimationType _currentAnimation;


        public void PlayIdle() => 
            SetAnimation(CharacterAnimationType.Idle);

        public void PlayWalking() => 
            SetAnimation(CharacterAnimationType.Walking);

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            SetAnimation(CharacterAnimationType.Idle);
        }

        private void SetAnimation(CharacterAnimationType animation)
        {
            if (_currentAnimation == animation)
                return;
            
            _currentAnimation = animation;
            _animator.Play(animation.ToString());
        }
    }
}
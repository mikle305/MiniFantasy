using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Services
{
    public class JumpTween : TweenBase
    {
        private JumpTweenData _tweenData;


        public void Init(JumpTweenData tweenData)
        {
            _tweenData = tweenData;
        }

        protected override Tween DoTween()
        {
            Vector3 targetPosition = transform.localPosition + _tweenData.Distance;
            return transform
                .DOLocalJump(targetPosition, _tweenData.Power, 0, _tweenData.Duration)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}
using DG.Tweening;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class RotateAroundTween : TweenBase
    {
        private RotateTweenData _tweenData;
        

        public void Init(RotateTweenData tweenData)
        {
            _tweenData = tweenData;
        }

        protected override Tween DoTween()
        {
            Vector3 targetRotation = transform.localRotation.eulerAngles + _tweenData.Rotation;
            return transform
                .DOLocalRotate(targetRotation, _tweenData.Duration, RotateMode.FastBeyond360)
                .SetRelative(true)
                .SetEase(Ease.Linear)
                .SetLoops(-1);
        }
    }
}
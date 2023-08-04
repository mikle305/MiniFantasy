using DG.Tweening;
using StaticData;

namespace Infrastructure.Services
{
    public class ScaleTween : TweenBase
    {
        private ScaleTweenData _tweenData;
        

        public void Init(ScaleTweenData tweenData)
        {
            _tweenData = tweenData;
        }

        protected override Tween DoTween()
            => transform
                .DOPunchScale(_tweenData.Scale, _tweenData.Duration,  vibrato: 2, elasticity: 0)
                .SetLoops(-1);
    }
}
using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Services
{
    public abstract class TweenBase : MonoBehaviour
    {
        private Tween _tween;

        
        public void StartTween()
            => _tween = DoTween();

        private void OnDestroy() 
            => _tween?.Kill();

        protected abstract Tween DoTween();
    }
}
using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Services
{
    public class LootScaleAnimation : MonoBehaviour
    {
        public void Init()
        {
            PlayAnim();
        }

        private void PlayAnim()
        {
            transform.DOShakeScale().SetLoops(-1);
        }
    }
}
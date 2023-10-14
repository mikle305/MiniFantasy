using Additional.Utils;
using StaticData;
using UnityEngine;

namespace GamePlay.Units.Hit
{
    public class EffectOnHit : MonoBehaviour
    {
        [SerializeField] private HitOnDamage _hitOnDamage;
        
        private Effect _effect;

        
        public void Init(Effect effect)
        {
            _effect = effect;
            _hitOnDamage.Started += PlayEffect;
        }
        
        private void PlayEffect() 
            => GameUtils.PlayEffect(_effect, transform);
    }
}
using Additional.Utils;
using StaticData;
using UnityEngine;

namespace GamePlay.Units.Animations
{
    public class EffectOnDeath : MonoBehaviour
    {
        private Effect _effect;

        public void Init(Effect effect)
        {
            _effect = effect;
            GetComponent<DeathOnDamage>().Happened += PlayEffect;
        }
        
        private void PlayEffect() 
            => GameUtils.PlayEffect(_effect, transform);
    }
}
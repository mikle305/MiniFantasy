using Additional.Utils;
using StaticData;
using UnityEngine;

namespace GamePlay.Units.Death
{
    public class EffectOnDeath : MonoBehaviour
    {
        [SerializeField] private Death _death;
        
        private Effect _effect;

        
        public void Init(Effect effect)
        {
            _effect = effect;
            _death.Happened += PlayEffect;
        }
        
        private void PlayEffect() 
            => GameUtils.PlayEffect(_effect, transform);
    }
}
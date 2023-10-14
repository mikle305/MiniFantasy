using Additional.Utils;
using StaticData;
using UnityEngine;

namespace GamePlay.LootSystem
{
    public class LootEffect : MonoBehaviour
    {
        private Effect _effect;

        
        public void Init(Effect effect)
        {
            _effect = effect;
        }

        public void PlayEffect() 
            => GameUtils.PlayEffect(_effect, transform);
    }
}
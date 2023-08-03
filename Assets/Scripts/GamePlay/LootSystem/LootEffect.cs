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
            PlayEffect(_effect);
        }

        private static void PlayEffect(Effect effect) 
            => GameUtils.PlayEffect(effect);
    }
}
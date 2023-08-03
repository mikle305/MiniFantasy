using StaticData;
using UnityEngine;

namespace Additional.Utils
{
    public static class GameUtils
    {
        public static void PlayEffect(Effect effect, Transform parent)
        {
            if (effect != null)
                Object.Instantiate(effect.Prefab, effect.Position, Quaternion.identity, parent);
        }
        
        public static void PlayEffect(Effect effect)
        {
            if (effect != null)
                Object.Instantiate(effect.Prefab, effect.Position, Quaternion.identity);
        }
    }
}
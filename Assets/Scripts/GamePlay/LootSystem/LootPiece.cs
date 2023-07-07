using StaticData;
using UnityEngine;

namespace GamePlay.LootSystem
{
    public class LootPiece : MonoBehaviour
    {
        public LootStaticData LootData { get; private set; }
        public int CurrentCount { get; set; }
        

        public void Init(LootStaticData lootData, int count)
        {
            LootData = lootData;
            CurrentCount = count;
        }

        public void Disappear() 
            => Destroy(gameObject);
    }
}
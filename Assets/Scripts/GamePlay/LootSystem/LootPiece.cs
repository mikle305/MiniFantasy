using StaticData;
using UnityEngine;

namespace GamePlay.LootSystem
{
    public class LootPiece : MonoBehaviour
    {
        public LootData LootData { get; private set; }
        public int CurrentCount { get; set; }
        

        public void Init(LootData lootData, int count)
        {
            LootData = lootData;
            CurrentCount = count;
        }

        public void Disappear() 
            => Destroy(gameObject);
    }
}
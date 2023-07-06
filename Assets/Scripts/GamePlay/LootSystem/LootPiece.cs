using StaticData;
using UnityEngine;

namespace GamePlay.LootSystem
{
    public class LootPiece : MonoBehaviour
    {
        private int _currentCount;
        
        public LootId LootId { get; private set; }


        public void Init(LootStaticData lootData) 
            => LootData = lootData;

        public LootStaticData LootData { get; private set; }

        public void SetCount(int count)
            => _currentCount = count;

        public int PickUpAll()
            => PickUp(_currentCount);

        private int PickUp(int targetCount)
        {
            int left = _currentCount - targetCount;
            if (left <= 0) 
                targetCount = _currentCount;

            _currentCount -= targetCount;
            return targetCount;
        }

        public void Disappear() 
            => Destroy(gameObject);
    }
}
using UnityEngine;

namespace GamePlay.LootSystem
{
    public class LootPiece : MonoBehaviour
    {
        private int _currentCount;
        
        public LootId LootId { get; private set; }


        public void Init(LootId lootId, int count)
        {
            LootId = lootId;
            _currentCount = count;
        }

        public int PickUpAll()
            => PickUp(_currentCount);

        public int PickUp(int targetCount)
        {
            int left = _currentCount - targetCount;
            if (left <= 0)
            {
                Disappear();
                targetCount = _currentCount;
            }

            _currentCount -= targetCount;
            return targetCount;
        }

        private void Disappear() 
            => Destroy(gameObject);
    }
}
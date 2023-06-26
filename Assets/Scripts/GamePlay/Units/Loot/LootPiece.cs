using UnityEngine;

namespace GamePlay.Units.Loot
{
    public class LootPiece : MonoBehaviour
    {
        private int _count;

        public void Init(int count)
        {
            _count = count;
        }
    }
}
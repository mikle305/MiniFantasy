using UnityEngine;

namespace GamePlay.LootSystem
{
    public abstract class PickupHandler : MonoBehaviour
    {
        public abstract void Handle(LootPiece lootPiece);
    }
}
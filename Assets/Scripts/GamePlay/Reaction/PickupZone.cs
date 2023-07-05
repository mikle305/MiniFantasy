using GamePlay.LootSystem;
using UnityEngine;

namespace GamePlay.Reaction
{
    public class PickupZone : ReactionZone
    {
        [SerializeField] private PickupHandler _pickupHandler;
        
        protected override void OnObjectEntered(Collider entered)
        {
            if (!entered.TryGetComponent(out LootPiece lootPiece))
                return;
            
            _pickupHandler.Handle(lootPiece);
        }

        protected override void OnObjectExited(Collider exited)
        {
        }
    }
}
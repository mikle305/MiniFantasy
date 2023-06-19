using UnityEngine;

namespace Domain.Reaction
{
    public abstract class ReactionZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        
        
        private void Start()
        {
            _triggerObserver.TriggerEntered += ObjectEntered;
            _triggerObserver.TriggerExited += ObjectExited;
        }

        protected abstract void ObjectEntered(Collider entered);
        
        protected abstract void ObjectExited(Collider exited);
    }
}
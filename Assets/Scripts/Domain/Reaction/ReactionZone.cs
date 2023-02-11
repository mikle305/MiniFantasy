using UnityEngine;

namespace Domain.Reaction
{
    public abstract class ReactionZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        
        
        private void Start()
        {
            _triggerObserver.TriggerEntered += OnTriggerEntered;
            _triggerObserver.TriggerExited += OnTriggerExited;
        }

        protected abstract void OnTriggerEntered(Collider entered);
        
        protected abstract void OnTriggerExited(Collider entered);
    }
}
using UnityEngine;

namespace GamePlay.Reaction
{
    public abstract class ReactionZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        
        
        private void Start()
        {
            _triggerObserver.ObjectEntered += OnObjectEntered;
            _triggerObserver.ObjectExited += OnObjectExited;
        }

        protected abstract void OnObjectEntered(Collider entered);
        
        protected abstract void OnObjectExited(Collider exited);
    }
}
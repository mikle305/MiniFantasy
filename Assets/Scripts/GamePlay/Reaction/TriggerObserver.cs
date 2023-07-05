using System;
using UnityEngine;

namespace GamePlay.Reaction
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> ObjectEntered;
        
        public event Action<Collider> ObjectExited;


        private void OnTriggerEnter(Collider other) 
            => ObjectEntered?.Invoke(other);

        private void OnTriggerExit(Collider other) 
            => ObjectExited?.Invoke(other);
    }
}

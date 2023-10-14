using UnityEngine;

namespace GamePlay.Units.Death
{
    public class NonCollisionOnDeath : MonoBehaviour
    {
        [SerializeField] private Death _death;
        
        private Collider[] _colliders;

        
        private void Awake()
        {
            _colliders = transform.GetComponents<Collider>(); 
            _death.Happened += DisableColliders;
        }

        private void DisableColliders()
        {
            foreach (Collider col in _colliders) 
                col.enabled = false;
        }
    }
}
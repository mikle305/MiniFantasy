using UnityEngine;

namespace Domain.Units.Animations
{
    public class NonCollisionOnDeath : MonoBehaviour
    {
        private Collider[] _colliders;

        private void Awake()
        {
            _colliders = GetComponents<Collider>();
            GetComponent<DeathOnDamage>().Happened += DisableColliders;
        }

        private void DisableColliders()
        {
            foreach (Collider col in _colliders) 
                col.enabled = false;
        }
    }
}
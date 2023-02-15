using UnityEngine;

namespace Domain.Units.Stats
{
    [RequireComponent(typeof(Health))]
    public class HealthInitializer : MonoBehaviour
    {
        [SerializeField] private float _baseHealth;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _health.Init(_baseHealth, _baseHealth);
        }
    }
}
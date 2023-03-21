using Domain.StatsSystem;
using UnityEngine;

namespace Domain.Units.Enemy
{
    public class EnemyHealth : Health.Health
    {
        [SerializeField] private float _defaultValue;
        
        private void Awake()
        {
            _max = new ModifiableStat(_defaultValue);
            _current = new DefaultStat(_defaultValue);
        }
    }
}
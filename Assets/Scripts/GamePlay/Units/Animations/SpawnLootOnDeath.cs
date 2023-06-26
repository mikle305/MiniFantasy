using GamePlay.Units.Loot;
using UnityEngine;

namespace GamePlay.Units.Animations
{
    public class SpawnLootOnDeath : MonoBehaviour
    {
        private LootSpawner _lootSpawner;
        private DeathOnDamage _death;

        private void Awake()
        {
            _death = GetComponent<DeathOnDamage>();
            _lootSpawner = GetComponent<LootSpawner>();
            _death.Happened += _lootSpawner.Spawn;
        }
    }
}
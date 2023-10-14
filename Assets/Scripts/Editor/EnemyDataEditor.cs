using System.Collections.Generic;
using Editor.Utils;
using StaticData;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(EnemyData))]
    public class EnemyDataEditor : UnityEditor.Editor
    {
        private static EnemyData _enemyData;

        private void OnEnable()
        {
            _enemyData = target as EnemyData;
        }

        private void OnDisable()
        {
            ValidateLoot(_enemyData);
        }

        public static void ValidateLoot(EnemyData enemyData)
        {
            List<RandomLoot> lootCollection = enemyData.LootCollection;
            for (var i = 0; i < lootCollection.Count; i++)
            {
                RandomLoot loot = lootCollection[i];
                if (loot.Chance < 0)
                    ThrowInvalidLootData(nameof(RandomLoot.Chance));

                if (loot.MinCount < 0)
                    ThrowInvalidLootData(nameof(loot.MinCount));

                if (loot.MaxCount < 0)
                    ThrowInvalidLootData(nameof(loot.MaxCount));

                if (loot.MinCount > loot.MaxCount)
                    ThrowInvalidLootCountRange();
                
                
                
                void ThrowInvalidLootData(string fieldName)
                {
                    ThrowHelper.InvalidEnemyLootData(fieldName, enemyData.name, i);
                }

                void ThrowInvalidLootCountRange()
                {
                    ThrowHelper.InvalidEnemyLootCountRange(enemyData.name, i);
                }
            }
        }
    }
}
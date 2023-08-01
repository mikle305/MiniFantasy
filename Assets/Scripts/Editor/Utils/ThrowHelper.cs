using UnityEngine;

namespace Editor.Utils
{
    public static class ThrowHelper
    {
        public static void InvalidEnemyLootData(string fieldName, string enemyDataName, int collectionIndex)
            => Debug.LogError(
                message: $"Invalid loot data in {enemyDataName} data" +
                         $"\nLoot element {collectionIndex}, Field {fieldName}");

        public static void InvalidEnemyLootCountRange(string enemyDataName, int collectionIndex)
            => Debug.LogError(
                message: $"Invalid loot min-max count in {enemyDataName} data" +
                         $"\nLoot element {collectionIndex}");
    }
}
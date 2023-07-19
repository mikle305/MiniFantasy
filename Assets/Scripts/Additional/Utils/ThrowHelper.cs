using System;
using GamePlay.Units;
using UnityEngine;

namespace Additional.Utils
{
    public static class ThrowHelper
    {
        public static void ValueLessThanZero() 
            => throw new ArgumentException("Value must be not not less than zero");

        public static void CharacterDeathComponentIsRequired() 
            => throw new MissingComponentException("Character death component is required for game process");
        
        public static void NotImplementedEnemyType(EnemyId enemyId)
            => throw new NotImplementedException($"{enemyId.ToString()} is not implemented in spawner get factory method");

        public static void InvalidChance() 
            => throw new ArgumentException("Invalid chance value");

        public static void LootIdIsNone() 
            => throw new ArgumentException("Loot id can not be none.\nProbably need it's not set in loot config");

        public static void InvalidState(Type state) 
            => throw new InvalidOperationException($"State machine doesn't contain {state.Name}");
    }
}
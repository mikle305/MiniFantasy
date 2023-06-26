using System;
using GamePlay.Units.Spawn;
using UnityEngine;

namespace Additional.Utils
{
    public static class ThrowHelper
    {
        public static void ValueLessThanZero() 
            => throw new ArgumentException("Value must be not not less than zero");

        public static void CharacterDeathComponentIsRequired() 
            => throw new MissingComponentException("Character death component is required for game process");
        
        public static void NotImplementedEnemyType(EnemyTypeId enemyTypeId)
            => throw new NotImplementedException($"{enemyTypeId.ToString()} is not implemented in spawner get factory method");

        public static void InvalidChance()
        {
            throw new ArgumentException("Invalid chance value");
        }
    }
}
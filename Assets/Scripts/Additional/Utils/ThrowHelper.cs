using System;
using GamePlay.Units;
using GamePlay.Units.Enemy;
using GamePlay.WeaponSystem;
using StaticData;
using UnityEngine;

namespace Additional.Utils
{
    public static class ThrowHelper
    {
        public static void ValueLessThanZero() 
            => throw new ArgumentException("Value must be not not less than zero");

        public static void CharacterDeathComponentIsRequired() 
            => throw new MissingComponentException("Character death component is required for game process");

        public static void InvalidChance() 
            => throw new ArgumentException("Invalid chance value");

        public static void InvalidState(Type state) 
            => throw new InvalidOperationException($"State machine doesn't contain {state.Name}");

        public static void LootIdIsNone() 
            => throw new ArgumentException("Loot id can not be none." +
                                           "\nProbably it isn't set in loot config");
        
        public static void SoNotExists()
            => throw new InvalidOperationException("Scriptable object data doesn't exist or didn't loaded.");

        public static void InvalidLootType<TData>()
            => throw new InvalidCastException($"Requested loot data is not the {typeof(TData).Name} type");

        public static void InvalidWeaponComponentType(Type componentType) => 
            throw new InvalidCastException($"Type {componentType.Name} is not derived from {nameof(WeaponComponent)}");
    }
}
using System;
using UnityEngine;

namespace Additional.Utils
{
    public static class ThrowHelper
    {
        public static void ValueLessThanZero() 
            => throw new ArgumentException("Value must be not not less than zero");

        public static void CharacterDeathComponentIsRequired() 
            => throw new MissingComponentException("Character death component is required for game process");
    }
}
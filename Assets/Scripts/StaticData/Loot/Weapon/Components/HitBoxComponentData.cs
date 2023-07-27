using System;
using GamePlay.WeaponSystem;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class HitBoxComponentData : WeaponComponentData
    {
        [SerializeField] private float _distance;
        
        private Type _componentType;

        
        public override Type GetComponentType()
            => _componentType ??= typeof(HitBoxComponent);
    }
}
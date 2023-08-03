using System;
using GamePlay.WeaponSystem;
using GamePlay.WeaponSystem.Components;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class HitBoxComponentData : WeaponComponentData
    {
        [SerializeField] private float _distance;

        public float Distance => _distance;
        

        protected override Type CreateComponentType()
            => typeof(HitBoxComponent);
    }
}
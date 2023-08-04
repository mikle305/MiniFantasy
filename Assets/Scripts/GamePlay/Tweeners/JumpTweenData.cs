using System;
using UnityEngine;

namespace Infrastructure.Services
{
    [Serializable]
    public class JumpTweenData
    {
        [SerializeField] private Vector3 _distance = new(0, 0.2f, 0);
        [SerializeField] private float _power = 0.5f;
        [SerializeField] private float _duration = 2;
        
        
        public Vector3 Distance => _distance;
        public float Power => _power;
        public float Duration => _duration;
    }
}
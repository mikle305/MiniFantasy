using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class RotateTweenData
    {
        [SerializeField] private Vector3 _rotation = new(0, 360, 0);
        [SerializeField] private float _duration = 3;


        public Vector3 Rotation => _rotation;
        public float Duration => _duration;
    }
}
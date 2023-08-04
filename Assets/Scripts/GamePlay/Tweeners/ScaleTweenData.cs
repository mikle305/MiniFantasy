using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class ScaleTweenData
    {
        [SerializeField] private Vector3 _scale = new(0.15f, 0.15f, 0.15f);
        [SerializeField] private float _duration = 2;


        public Vector3 Scale => _scale;
        public float Duration => _duration;
    }
}
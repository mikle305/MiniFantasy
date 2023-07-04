using System;
using UnityEngine;

namespace StaticData
{
    [Serializable]
    public class Effect
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Vector3 _position;

        
        public GameObject Prefab => _prefab;
        public Vector3 Position => _position;
    }
}
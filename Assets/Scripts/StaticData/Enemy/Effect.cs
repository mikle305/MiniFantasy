using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace StaticData
{
    [Serializable]
    public class Effect
    {
        [SerializeField] [FormerlySerializedAs("Prefab")] private GameObject _prefab;
        [SerializeField] [FormerlySerializedAs("Position")] private Vector3 _position;

        
        public GameObject Prefab => _prefab;
        public Vector3 Position => _position;
    }
}
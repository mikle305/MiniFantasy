﻿using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public interface IEnemyFactory : IService
    {
        public GameObject CreateNinja(Vector3 position);
        
        public GameObject CreateSkeletonArcher(Vector3 position);
    }
}
﻿using Models;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateCharacter(World world);
        
        public World CreateWorld();
        
        public void CreateHud();
    }
}
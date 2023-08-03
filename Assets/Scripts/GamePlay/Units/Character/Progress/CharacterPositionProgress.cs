using System;
using Additional.Extensions;
using Data;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GamePlay.Units.Character
{
    [Serializable]
    public class CharacterPositionProgress : ProgressPartWriter
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private Transform _transform;

        
        public override void ReadProgress(GameProgress progress)
        {
            LevelData levelData = progress.Character.CurrentLevel;
            if (levelData.Name != GetCurrentLevel())
                return;

            Vector3Data savedPosition = levelData.Position;
            if (savedPosition == null)
                return;

            _characterMovement.Warp(to: savedPosition.ToUnityVector());
        }

        public override void WriteProgress(GameProgress progress)
        {
            progress.Character.CurrentLevel = new LevelData
            {
                Name = GetCurrentLevel(),
                Position = GetCurrentPosition()
            };
        }

        private static string GetCurrentLevel() 
            => SceneManager.GetActiveScene().name;

        private Vector3Data GetCurrentPosition() 
            => _transform.position.ToVectorData();
    }
}
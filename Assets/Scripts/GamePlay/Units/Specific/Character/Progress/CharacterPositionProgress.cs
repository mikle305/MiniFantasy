using Additional.Extensions;
using Data;
using Infrastructure.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Domain.Units.Character.Progress
{
    public class CharacterPositionProgress : ISavedProgressWriter
    {
        private readonly CharacterMovement _characterMovement;
        private readonly Transform _transform;

        
        public CharacterPositionProgress(CharacterMovement characterMovement, Transform transform)
        {
            _characterMovement = characterMovement;
            _transform = transform;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            LevelPosition levelPosition = progress.WorldData.LevelPosition;
            if (levelPosition.Level != GetCurrentLevel())
                return;

            Vector3Data savedPosition = levelPosition.Position;
            if (savedPosition == null)
                return;

            _characterMovement.Warp(to: savedPosition.ToUnityVector());
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.LevelPosition = new LevelPosition
            {
                Level = GetCurrentLevel(),
                Position = _transform.position.ToVectorData()
            };
        }

        private static string GetCurrentLevel() 
            => SceneManager.GetActiveScene().name;
    }
}
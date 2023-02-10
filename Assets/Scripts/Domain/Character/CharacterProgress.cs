using Additional.Extensions;
using Data;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Domain.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class CharacterProgress : MonoBehaviour, ISavedProgressWriter
    {
        private CharacterMovement _characterMovement;

        private void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
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
                Position = transform.position.ToVectorData()
            };
        }

        private static string GetCurrentLevel() 
            => SceneManager.GetActiveScene().name;
    }
}
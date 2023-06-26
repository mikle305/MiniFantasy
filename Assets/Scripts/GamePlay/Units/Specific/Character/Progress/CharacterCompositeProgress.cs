using System.Collections.Generic;
using Data;
using GamePlay.Units.Health;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class CharacterCompositeProgress : MonoBehaviour, ISavedProgressWriter
    {
        private CharacterMovement _characterMovement;
        private IHealth _health;
        
        private readonly List<ISavedProgressWriter> _characterProgressParts = new();

        
        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _characterMovement = GetComponent<CharacterMovement>();
            RegisterProgressParts();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            foreach (ISavedProgressWriter progressReader in _characterProgressParts)
            {
                progressReader.LoadProgress(progress);
            }
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            foreach (ISavedProgressWriter progressWriter in _characterProgressParts)
            {
                progressWriter.UpdateProgress(progress);
            }
        }

        private void RegisterProgressParts()
        {
            var positionProgress = new CharacterPositionProgress(_characterMovement, transform);
            var statsProgress = new CharacterHealthProgress(_health);

            _characterProgressParts.Add(positionProgress);
            _characterProgressParts.Add(statsProgress);
        }
    }
}
using System.Collections.Generic;
using Data;
using Domain.Units.Stats;
using Infrastructure.Services.Progress;
using UnityEngine;

namespace Domain.Units.Specific.Character.Progress
{
    public class CharacterCompositeProgress : MonoBehaviour, ISavedProgressWriter
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private Health _health;
        
        private readonly List<ISavedProgressWriter> _characterProgressParts = new();

        
        private void Awake()
        {
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
            var statsProgress = new CharacterStatsProgress(_health);

            _characterProgressParts.Add(positionProgress);
            _characterProgressParts.Add(statsProgress);
        }
    }
}
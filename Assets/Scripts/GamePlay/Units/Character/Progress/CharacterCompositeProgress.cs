using System.Collections.Generic;
using Data;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class CharacterCompositeProgress : MonoBehaviour, ISavedProgressWriter
    {
        private CharacterMovement _characterMovement;
        private Health _health;
        
        private readonly List<ISavedProgressWriter> _characterProgressParts = new();

        
        private void Awake()
        {
            _health = GetComponent<Health>();
            _characterMovement = GetComponent<CharacterMovement>();
            RegisterProgressParts();
        }

        public void ReadProgress(PlayerProgress progress)
        {
            foreach (ISavedProgressWriter progressReader in _characterProgressParts)
            {
                progressReader.ReadProgress(progress);
            }
        }

        public void WriteProgress(PlayerProgress progress)
        {
            foreach (ISavedProgressWriter progressWriter in _characterProgressParts)
            {
                progressWriter.WriteProgress(progress);
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
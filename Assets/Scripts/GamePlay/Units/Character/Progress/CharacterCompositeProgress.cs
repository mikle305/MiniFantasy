using System.Collections.Generic;
using Data;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class CharacterCompositeProgress : MonoBehaviour, IProgressWriter
    {
        [SerializeReference] private List<ProgressPartWriter> _progressParts = new()
        {
            new CharacterHealthProgress(),
            new CharacterPositionProgress(),
        };

        public void ReadProgress(GameProgress progress)
        {
            foreach (IProgressWriter progressReader in _progressParts) 
                progressReader.ReadProgress(progress);
        }

        public void WriteProgress(GameProgress progress)
        {
            foreach (IProgressWriter progressWriter in _progressParts) 
                progressWriter.WriteProgress(progress);
        }
    }
}
using System;
using Data;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Character
{
    [Serializable]
    public class CharacterHealthProgress : ProgressPartWriter
    {
        [SerializeField] private Health _health;
        
        
        public override void ReadProgress(GameProgress progress)
        {
            CharacterStatsData statsData = progress.Character.Stats;
            
            _health.Init(statsData.Health.MaxValue, statsData.Health.MaxValue);
        }

        public override void WriteProgress(GameProgress progress)
        {
            CharacterStatsData statsData = progress.Character.Stats;
            
            statsData.Health.MaxValue = _health.MaxValue;
        }
    }
}
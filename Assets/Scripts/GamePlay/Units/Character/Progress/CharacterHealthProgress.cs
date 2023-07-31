﻿using Data;
using Infrastructure.Services;

namespace GamePlay.Units.Character
{
    public class CharacterHealthProgress : ISavedProgressWriter
    {
        private readonly Health _health;

        public CharacterHealthProgress(Health health)
        {
            _health = health;
        }
        
        public void ReadProgress(PlayerProgress progress)
        {
            CharacterStatsData statsData = progress.CharacterStats;
            
            _health.Init(statsData.Health.MaxValue, statsData.Health.MaxValue);
        }

        public void WriteProgress(PlayerProgress progress)
        {
            CharacterStatsData statsData = progress.CharacterStats;
            
            statsData.Health.MaxValue = _health.MaxValue;
        }
    }
}
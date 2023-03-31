using Data;
using Infrastructure.Services;

namespace Domain.Units.Character.Progress
{
    public class CharacterHealthProgress : ISavedProgressWriter
    {
        private readonly CharacterHealth _health;

        public CharacterHealthProgress(CharacterHealth health)
        {
            _health = health;
        }
        
        public void LoadProgress(PlayerProgress progress)
        {
            CharacterStatsData statsData = progress.CharacterStats;
            
            _health.Init(statsData.Health.MaxValue, statsData.Health.MaxValue);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            CharacterStatsData statsData = progress.CharacterStats;
            
            statsData.Health.MaxValue = _health.MaxValue;
        }
    }
}
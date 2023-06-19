using Data;
using Domain.Units.Health;
using Infrastructure.Services;

namespace Domain.Units.Character.Progress
{
    public class CharacterHealthProgress : ISavedProgressWriter
    {
        private readonly IHealth _health;

        public CharacterHealthProgress(IHealth health)
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
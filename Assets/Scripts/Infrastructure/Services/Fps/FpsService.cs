using System.Linq;
using Additional.Constants;
using UnityEngine;

namespace Infrastructure.Services.Fps
{
    public class FpsService : IFpsService, ITickable
    {
        private readonly float[] _cachedFramesDurations;
        private int _lastCachedFrameIndex = -1;

        public FpsService()
        {
            _cachedFramesDurations = Enumerable.Repeat(0.01f, AppSettings.CachedFramesCount).ToArray();
        }
        
        public int CalculateFps()
        {
            float averageFps = AppSettings.CachedFramesCount / _cachedFramesDurations.Sum();
            return Mathf.RoundToInt(averageFps);
        }

        public void SetTargetFps(int fps)
        {
            Application.targetFrameRate = fps;
            QualitySettings.vSyncCount = 1;
        }

        public void SetTargetFpsUnlimited()
        {
            Application.targetFrameRate = -1;
            QualitySettings.vSyncCount = 0;
        }

        public void OnTick()
        {
            _lastCachedFrameIndex = ++_lastCachedFrameIndex % AppSettings.CachedFramesCount;
            _cachedFramesDurations[_lastCachedFrameIndex] = Time.unscaledDeltaTime;
        }
    }
}
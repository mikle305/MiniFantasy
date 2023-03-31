using System;
using System.Collections;
using System.Linq;
using Additional.Constants;
using UnityEngine;

namespace Infrastructure.Services
{
    public class FpsService : IFpsService, IDisposable
    {
        private readonly float[] _cachedFramesDurations;
        private int _lastCachedFrameIndex = -1;
        private readonly Coroutine _cacheFrameDurationCoroutine;
        private readonly ICoroutineRunner _coroutineRunner;


        public FpsService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _cachedFramesDurations = Enumerable.Repeat(0.01f, AppSettings.CachedFramesCount).ToArray();
            _cacheFrameDurationCoroutine = _coroutineRunner.StartCoroutine(CacheFrameDurationLoop());
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
        
        public void Dispose()
        {
            _coroutineRunner.StopCoroutine(_cacheFrameDurationCoroutine);
        }

        private IEnumerator CacheFrameDurationLoop()
        {
            while (true)
            {
                yield return null;
                
                _lastCachedFrameIndex = (_lastCachedFrameIndex + 1) % AppSettings.CachedFramesCount;
                _cachedFramesDurations[_lastCachedFrameIndex] = Time.unscaledDeltaTime;
            }
        }
    }
}
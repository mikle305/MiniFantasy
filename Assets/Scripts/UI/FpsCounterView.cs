using System.Collections;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class FpsCounterView : MonoBehaviour
    {
        
        [SerializeField] private float _uiRefreshTime = 1f;
        [SerializeField] private int _cachedFramesCount = 50;

        private float[] _cachedFramesDurations;
        private int _lastCachedFrameIndex = -1;
        private Text _text;

        
        private void Awake()
        {
            _cachedFramesDurations = Enumerable.Repeat(0.01f, _cachedFramesCount).ToArray();
            _text = GetComponent<Text>();

            StartCoroutine(ShowFpsLoop());
        }

        private void Update()
        {
            _lastCachedFrameIndex = ++_lastCachedFrameIndex % _cachedFramesCount;
            _cachedFramesDurations[_lastCachedFrameIndex] = Time.unscaledDeltaTime;
        }

        private IEnumerator ShowFpsLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(_uiRefreshTime);

                _text.text = CalculateFps().ToString(CultureInfo.InvariantCulture);
            }
        }

        private int CalculateFps()
        {
            float averageFps = _cachedFramesCount / _cachedFramesDurations.Sum();
            return Mathf.RoundToInt(averageFps);
        }
    }
}

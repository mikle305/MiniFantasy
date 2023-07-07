using System.Collections;
using System.Globalization;
using Additional.Constants;
using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class FpsCounterView : MonoBehaviour
    {
        private Text _text;
        private IFpsService _fpsService;

        [Inject]
        public void Construct(IFpsService fpsService)
        {
            _fpsService = fpsService;
        }

        private void Awake()
        {
            _text = GetComponent<Text>();
            
            StartCoroutine(ShowFpsLoop());
        }

        private IEnumerator ShowFpsLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(AppSettings.FpsViewRefreshTime);

                _text.text = _fpsService.CalculateFps().ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}

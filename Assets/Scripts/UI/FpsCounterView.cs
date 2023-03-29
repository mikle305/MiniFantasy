using System.Collections;
using System.Globalization;
using Additional.Constants;
using Infrastructure.Services;
using Infrastructure.Services.Fps;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class FpsCounterView : MonoBehaviour
    {
        private Text _text;
        private IFpsService _fpsService;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _fpsService = ServiceProvider.Container.Resolve<IFpsService>();
            
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

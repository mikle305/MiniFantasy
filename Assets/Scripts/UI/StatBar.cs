using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StatBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;

        public void SetValue(float current, float max)
            => _fillImage.fillAmount = current / max;
    }
}

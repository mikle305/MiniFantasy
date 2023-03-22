using UnityEngine;

namespace Domain.Units.Animations
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private GameObject _effectObject;
        
        public void Play()
        {
            Instantiate(_effectObject, transform.position, Quaternion.identity);
        }
    }
}
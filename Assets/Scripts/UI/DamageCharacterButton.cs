using Domain.Units.Character;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class DamageCharacterButton : MonoBehaviour
    {
        [SerializeField] private float _damage = 1.0f;
        
        private CharacterHealth _health;
        private Button _button;
        
        
        private void Start()
        {
            _health = FindObjectOfType<CharacterState>().GetComponent<CharacterHealth>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _health.TakeDamage(_damage);
        }
    }
}
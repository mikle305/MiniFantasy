using Domain.Units.Character;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class DamageCharacterButton : MonoBehaviour
    {
        [SerializeField] private float _damage = 1.0f;
        
        private CharacterHealth _characterHealth;
        private Button _button;
        
        
        private void Start()
        {
            _characterHealth = FindObjectOfType<CharacterHealth>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _characterHealth.TakeDamage(_damage);
            Debug.Log($"{_characterHealth.CurrentValue()} / {_characterHealth.MaxValueWithBonuses()}");
        }
    }
}
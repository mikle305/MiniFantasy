using GamePlay.Units;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class DamageCharacterButton : MonoBehaviour
    {
        [SerializeField] private float _damage = 1.0f;
        
        private Health _health;
        private Button _button;
        
        
        private void Start()
        {
            _health = FindObjectOfType<CharacterState>().GetComponent<Health>();
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _health.TakeDamage(_damage);
        }
    }
}
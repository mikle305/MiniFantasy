using UnityEngine;

namespace Domain.Character
{
    public class CharacterAttacker : MonoBehaviour
    {
        [SerializeField] private float _attackDuration = 2.0f;

        public float AttackDuration => _attackDuration;
    }
}
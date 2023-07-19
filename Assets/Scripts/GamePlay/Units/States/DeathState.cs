using UnityEngine;

namespace GamePlay.Units.States
{
    public class DeathState : CharacterState
    {
        [SerializeField] private Death _death;

        public override void Enter()
        {
            _death.Die();
        }
    }
}
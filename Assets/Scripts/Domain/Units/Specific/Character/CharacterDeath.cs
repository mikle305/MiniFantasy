using System;
using Domain.Units.Animations;

namespace Domain.Units.Character
{
    public class CharacterDeath : DeathOnDamage
    {
        public event Action Destroyed;

        protected override void OnDestroyed()
        {
            Destroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
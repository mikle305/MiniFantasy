using UnityEngine;

namespace GamePlay.WeaponSystem
{
    public class WeaponHolder : MonoBehaviour
    {
        private Weapon _weapon;

        public void SetWeapon(Weapon weapon) 
            => _weapon = weapon;
    }
}
namespace GamePlay.WeaponSystem
{
    public abstract class WeaponComponent
    {
        private Weapon _weapon;

        public void SetWeapon(Weapon weapon)
            => _weapon = weapon;

        public void CleanUp()
            => _weapon = null;
    }
}
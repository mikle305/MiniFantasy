using StaticData;

namespace GamePlay.WeaponSystem
{
    public abstract class WeaponComponent
    {
        private Weapon _weapon;


        public abstract void InitData(WeaponComponentData componentData);

        public void InitWeapon(Weapon weapon)
            => _weapon = weapon;

        public virtual void CleanUp()
            => _weapon = null;
    }

    public abstract class WeaponComponent<TData> : WeaponComponent
        where TData : WeaponComponentData
    {
        protected TData _data;

        public sealed override void InitData(WeaponComponentData componentData) 
            => _data = componentData as TData;

        public override void CleanUp()
        {
            base.CleanUp();
            _data = null;
        }
    }
}
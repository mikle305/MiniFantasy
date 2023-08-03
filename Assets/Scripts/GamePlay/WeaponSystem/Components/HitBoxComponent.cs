using StaticData;

namespace GamePlay.WeaponSystem.Components
{
    public class HitBoxComponent : WeaponComponent<HitBoxComponentData>
    {
        public HitBoxComponent()
        {
            float test = _data.Distance;
        }
    }
}
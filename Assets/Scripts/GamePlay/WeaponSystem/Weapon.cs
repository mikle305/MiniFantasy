using UnityEngine;

namespace GamePlay.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        private WeaponComponentsCollection _componentsCollection;
        
        public WeaponComponentsCollection ComponentsCollection 
            => _componentsCollection ??= new WeaponComponentsCollection(this);
    }
}
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ICharacterConfigurator
    {
        public void Configure(GameObject character);
    }
}
using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.Units.Character
{
    public class CharacterSpawner : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private ICharacterConfigurator _configurator;

        [Inject]
        public void Construct(IGameFactory gameFactory, ICharacterConfigurator configurator)
        {
            _configurator = configurator;
            _gameFactory = gameFactory;
        }
        
        public GameObject Spawn(Transform world)
        {
            GameObject character = _gameFactory.CreateCharacter(transform.position, world);
            _configurator.Configure(character);
            return character;
        }
    }
}
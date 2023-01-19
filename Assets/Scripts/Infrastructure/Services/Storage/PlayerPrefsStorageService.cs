using Additional.Extensions;
using Data;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Services.Storage
{
    public class PlayerPrefsStorageService : IStorageService
    {
        private const string _progressKey = "Progress";

        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;


        public PlayerPrefsStorageService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach(ISavedProgressWriter progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_progressService.PlayerProgress);

            string progressJsonString = _progressService.PlayerProgress.ToJson();
            PlayerPrefs
                .SetString(_progressKey, progressJsonString);
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs
                .GetString(_progressKey)
                .FromJson<PlayerProgress>();
        }
    }
}
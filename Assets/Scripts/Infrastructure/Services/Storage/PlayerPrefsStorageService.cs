using Additional.Extensions;
using Data;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.ProgressWatchers;
using UnityEngine;

namespace Infrastructure.Services.Storage
{
    public class PlayerPrefsStorageService : IStorageService
    {
        private const string _progressKey = "Progress";

        private readonly IPersistentProgressAccess _progressAccess;
        private readonly IProgressWatchers _progressWatchers;


        public PlayerPrefsStorageService(
            IPersistentProgressAccess progressAccess, 
            IProgressWatchers progressWatchers)
        {
            _progressAccess = progressAccess;
            _progressWatchers = progressWatchers;
        }

        public void SaveProgress()
        {
            _progressWatchers.InformWriters();

            string progressJsonString = _progressAccess.PlayerProgress.ToJson();
            PlayerPrefs.SetString(_progressKey, progressJsonString);
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs
                .GetString(_progressKey)
                .FromJson<PlayerProgress>();
        }
    }
}
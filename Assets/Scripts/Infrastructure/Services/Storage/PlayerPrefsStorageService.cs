using Additional.Extensions;
using Data;
using UnityEngine;

namespace Infrastructure.Services
{
    public class PlayerPrefsStorageService : IStorageService
    {
        private const string _progressKey = "Progress";

        private readonly IProgressAccess _progressAccess;
        private readonly IProgressWatchers _progressWatchers;


        public PlayerPrefsStorageService(
            IProgressAccess progressAccess, 
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
using Additional.Extensions;
using Data;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad
{
    public class PlayerPrefsStorageService : IStorageService
    {
        private const string ProgressKey = "Progress";

        public void SaveProgress()
        {
            
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs
                .GetString(ProgressKey)
                .Deserialize<PlayerProgress>();
        }
    }
}
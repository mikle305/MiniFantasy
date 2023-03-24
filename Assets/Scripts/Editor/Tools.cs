using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class Tools
    {
        [MenuItem("Tools/Clear player prefs")]
        public static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}

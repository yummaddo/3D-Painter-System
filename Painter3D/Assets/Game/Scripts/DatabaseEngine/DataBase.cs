using System.IO;
using UnityEngine;

namespace Game.DatabaseEngine
{
    public class DataBase : MonoBehaviour
    {
        public SaveTable tableSave;
        public ISaveLoadTexture LoadSaveTexture;
        
        
        private static DataBase _instance;
        private void Awake()
        {
            _instance = this;
            LoadSaveTexture = new RenderTextureSaverLoader();
        }
        internal static DataBase Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = new GameObject().AddComponent<DataBase>();
                    _instance.name = _instance.GetType().ToString();
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }
        public static string DataPath(string saveFileName) {
#if UNITY_EDITOR
            return Application.streamingAssetsPath + $"/{saveFileName}";
#endif
            if (Directory.Exists(Application.persistentDataPath))
            {
                return Application.persistentDataPath + $"/{saveFileName}";
            }
            return Path.Combine(Application.streamingAssetsPath + $"/{saveFileName}");
        }
    }
}
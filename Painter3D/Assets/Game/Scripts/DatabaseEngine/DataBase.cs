using System;
using System.IO;
using Game.DatabaseEngine.Abstraction;
using Game.DatabaseEngine.Realizations;
using Game.DatabaseEngine.Realizations.Brash;
using Game.DatabaseEngine.Realizations.Mesh;
using Game.DatabaseEngine.SaveData;
using UnityEngine;

namespace Game.DatabaseEngine
{
    public class DataBase : MonoBehaviour
    {
        private static DataBase _instance;
        private readonly string _saveFileName = "Table_Of_Saves.json";
        private readonly string _saveBrashFileName = "Brash_Setting_Save.json";
        private SaveRepository _repositorySaves;
        private BrashRepository _repositoryBrash;
        public event Action OnRepositoryInit;

        public IRepositoryProvider<SaveRepository, SaveDataElement, SaveTableData> SaveProvider;
        public IRepositoryProvider<BrashRepository, BrashSettingData, BrashSettingData> BrashProvider;
        public ISaveLoadTexture LoadSaveTexture;

        public void Awake()
        {
            _instance = this;
            LoadSaveTexture = new RenderTextureSaverLoader();
            _repositorySaves = new SaveRepository(_saveFileName);
            _repositoryBrash = new BrashRepository(_saveBrashFileName);
            SaveProvider = new SaveRepositoryProvider(_repositorySaves);
            BrashProvider = new BrashRepositoryProvider(_repositoryBrash);
            OnRepositoryInit?.Invoke();
        }
        private void Dispose()
        {
            SaveProvider.OnDispose();
            BrashProvider.OnDispose();
        }
        
#if UNITY_WEBGL
        private void OnDestroy()
        {
            Dispose();
        }
#elif UNITY_IPHONE
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                Dispose(); 
            }
        }
#elif UNITY_EDITOR
        private void OnApplicationQuit()
        {
            Dispose();
        }
#elif UNITY_STANDALONE_WIN
        private void OnApplicationQuit()
        {
            Dispose();
        }
#else
        private void OnApplicationQuit()
        {
            Dispose();
        }
#endif
        
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
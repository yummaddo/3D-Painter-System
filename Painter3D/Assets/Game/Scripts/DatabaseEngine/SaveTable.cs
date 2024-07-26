using System;
using System.Collections.Generic;
using System.IO;
using Game.DatabaseEngine.SaveData;
using UnityEngine;
using Object = System.Object;

namespace Game.DatabaseEngine
{
    public class SaveTable : MonoBehaviour
    {
        private readonly string _saveFileName = "Table_Of_Saves.json";
        private readonly string _saveBrashFileName = "Brash_Setting_Save.json";
        private SaveRepository _repositorySaves;
        private BrashRepository _repositoryBrash;
        public event Action OnRepositoryInit;
        public void Awake()
        {
            _repositorySaves = new SaveRepository(_saveFileName);
            _repositoryBrash = new BrashRepository(_saveBrashFileName);
            _repositorySaves.Initialization();
            _repositoryBrash.Initialization();
            OnRepositoryInit?.Invoke();
        }
        public SaveTableData GetMeshSaves()
        {
            return _repositorySaves.data;
        }
        public BrashSettingData GetBrashSettingSaves()
        {
            return null;
        }
        public void Save(SaveDataElement element)
        {
            _repositorySaves.data.TryToAddElement(element);
            _repositorySaves.SaveResourceData();
        }
        public void Save(BrashSettingData element)
        {
            _repositoryBrash.data.dataBrash = element.dataBrash;
        }

        private void OnDestroy()
        {
            _repositoryBrash.SaveResourceData();
        }
    }
}
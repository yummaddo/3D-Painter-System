using System;
using System.IO;
using Game.Utility;
using UnityEngine;

namespace Game.DatabaseEngine.Abstraction
{
    [System.Serializable]
    public abstract class Repository<TSaveTableData> 
        where TSaveTableData : new()
    {
        public TSaveTableData data;
        private  string _saveFileName = "Table_Of_Saves.json";
        public Repository(string repositoryName)
        {
            _saveFileName = repositoryName;
            PublicAesLock = this;
        }

        protected object PublicAesLock { get; set; }
        internal  void WriteDataToJson(TSaveTableData savedData) {
            string dataString = "";
            string jsonFilePath = DataPath();
            CheckFileExist(jsonFilePath);
            dataString = JsonUtility.ToJson(savedData);
            File.WriteAllText(jsonFilePath, dataString);
        }
        internal string ReadDataFromJson() {
            string dataString = "";
            string jsonFilePath = DataPath();
            CheckFileExist(jsonFilePath, true);
            dataString = File.ReadAllText(jsonFilePath);
            return dataString;
        }
        internal TSaveTableData GetDataFromJson(string json)
        {
            lock (PublicAesLock)
            {
                var storageData = JsonUtility.FromJson<TSaveTableData>(json);
                data = storageData ?? new TSaveTableData();
                return data;
            }
        }
        internal  string DataPath() => DataBase.DataPath(_saveFileName);
        internal  void CheckFileExist(string filePath, bool isReading = false) 
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                if (isReading)
                {

                    data = GetVoidData();
                    var voidJson = JsonUtility.ToJson(data);
                    File.WriteAllText(filePath, voidJson);
                }
            }
        }

        public abstract TSaveTableData GetVoidData();
        public abstract void Initialization();
        internal void SaveResourceData()
        {
            try
            {
                lock (PublicAesLock)
                {
                    WriteDataToJson(data);
                }
            }
            catch (Exception e)
            {
                Debugger.Logger(e.Message, Process.TrashHold);
            }
        }
        protected string GetJsonData()
        {
            lock (PublicAesLock)
            {
                return JsonUtility.ToJson(data);
            }
        }
    }
}
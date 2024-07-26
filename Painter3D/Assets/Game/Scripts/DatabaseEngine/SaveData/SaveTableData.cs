using System.Collections.Generic;
using System.Linq;

namespace Game.DatabaseEngine.SaveData
{
    [System.Serializable]
    public class SaveTableData
    {
        public List<SaveDataElement> tableData;
        private Dictionary<string, SaveDataElement> _dataKeySet;
        public void TryToAddElement(SaveDataElement element)
        {
            if (_dataKeySet.ContainsKey(element.name))
                tableData.Remove((_dataKeySet[element.name]));
            _dataKeySet[element.name] = element;
            tableData.Add((_dataKeySet[element.name]));
        }
        public void TryToDelete(string element)
        {
            if (!_dataKeySet.ContainsKey(element)) return;
            
            tableData.Remove((_dataKeySet[element]));
            _dataKeySet.Remove(element);
        }
        public SaveTableData(List<SaveDataElement> tableData)
        {
            this.tableData = tableData;
            CreateKeySet(tableData);
        }
        public SaveTableData()
        {
            this.tableData = new List<SaveDataElement>();
            CreateKeySet(tableData);
        }
        private void CreateKeySet(List<SaveDataElement> tableDataElements)
        {
            _dataKeySet = new Dictionary<string, SaveDataElement>();
            _dataKeySet = tableDataElements.ToDictionary(tDataElement => tDataElement.name);
        }
        internal Dictionary<string, SaveDataElement> GetKeySet()
        {
            return _dataKeySet;
        }
    }
}
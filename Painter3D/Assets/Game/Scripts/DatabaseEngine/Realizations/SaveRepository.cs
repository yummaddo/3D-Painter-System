using System.Collections.Generic;
using Game.DatabaseEngine.SaveData;

namespace Game.DatabaseEngine
{
    public class SaveRepository : Repository<SaveTableData>
    {
        public SaveRepository(string repositoryName) : base(repositoryName)
        {
        }

        public override SaveTableData GetVoidData()
        {
            return  new SaveTableData(new List<SaveDataElement>());
        }

        public override void Initialization()
        {
            lock (PublicAesLock)
            {
                var jsonString = ReadDataFromJson();
                data = new SaveTableData(GetDataFromJson(jsonString).tableData);
            }
        }
    }
}
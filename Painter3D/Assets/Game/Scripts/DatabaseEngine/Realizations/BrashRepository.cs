using Game.DatabaseEngine.SaveData;

namespace Game.DatabaseEngine
{
    public class BrashRepository :  Repository<BrashSettingData>
    {
        public BrashRepository(string repositoryName) : base(repositoryName)
        {
        }

        public override BrashSettingData GetVoidData()
        {
            return new BrashSettingData();
        }

        public override void Initialization()
        {
            lock (PublicAesLock)
            {
                var jsonString = ReadDataFromJson();
                data = new BrashSettingData(GetDataFromJson(jsonString).dataBrash);
            }
        }
    }
}
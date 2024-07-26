using Game.DatabaseEngine.Abstraction;
using Game.DatabaseEngine.SaveData;

namespace Game.DatabaseEngine.Realizations.Brash
{
    public class BrashRepositoryProvider : IRepositoryProvider<BrashRepository, BrashSettingData, BrashSettingData>
    {
        public BrashRepository Repository { get; }
        
        public BrashRepositoryProvider(BrashRepository repository)
        {
            Repository = repository;
            Repository.Initialization();
        }
        
        public void SaveLoad(BrashSettingData element)
        {
            Repository.data.dataBrash = element.dataBrash;
        }
        public BrashSettingData SaveGet()
        {
            return Repository.data;
        }

        public void OnDispose()
        {
            Repository.SaveResourceData();
        }
    }
}
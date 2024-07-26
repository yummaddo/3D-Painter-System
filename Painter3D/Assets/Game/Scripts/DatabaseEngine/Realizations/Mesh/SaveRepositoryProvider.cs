using Game.DatabaseEngine.Abstraction;
using Game.DatabaseEngine.SaveData;

namespace Game.DatabaseEngine.Realizations.Mesh
{
    public class SaveRepositoryProvider : IRepositoryProvider<SaveRepository, SaveDataElement , SaveTableData>
    {
        public SaveRepository Repository { get; }

        public SaveRepositoryProvider(SaveRepository repository)
        {
            Repository = repository;
            Repository.Initialization();
        }

        public void SaveLoad(SaveDataElement element)
        {
            Repository.data.TryToAddElement(element);
            Repository.SaveResourceData();
        }

        public SaveTableData SaveGet()
        {
            return Repository.data;
        }

        public void OnDispose()
        {
            
        }
    }
}
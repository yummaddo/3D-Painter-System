namespace Game.DatabaseEngine.Abstraction
{
    public interface IRepositoryProvider<TRepository, in TData, out TGet> where  TRepository : Repository<TGet> where TGet : new()
    {
        public TRepository Repository { get; }
        public void SaveLoad(TData element);
        public TGet SaveGet();
        public void OnDispose();
    }
}
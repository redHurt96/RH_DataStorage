namespace _DataStorage.Logic
{
    public interface IStorage
    {
        bool IsEmpty { get; }
        void Create<T>(T value);
        T Read<T>();
        void UpdateValue<T>(T value);
        void Delete<T>();
    }
}
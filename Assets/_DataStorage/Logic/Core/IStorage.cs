namespace _DataStorage.Logic.Core
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
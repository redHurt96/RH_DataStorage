using System;
using System.Collections.Generic;
using UnityEngine;

namespace _DataStorage.Logic
{
    public class DataRepository
    {
        private readonly Dictionary<string, UniqueTypesStorage> _storages;

        public UniqueTypesStorage Get(string id)
        {
            return null;
        }
    }
    
    [Serializable]
    public class UniqueTypesStorage
    {
        public string Id => _id;

        [SerializeField] private string _id;
        
        private readonly Dictionary<Type, object> _data = new();
        
        public T Get<T>()
        {
            if (!_data.ContainsKey(typeof(T)))
                throw new($"Storage doesn't contains data with type {typeof(T).Name}");

            return (T)_data[typeof(T)];
        }

        public void Add<T>(T value)
        {
            if (_data.ContainsKey(typeof(T)))
                throw new($"Storage already contains data with type {typeof(T).Name}");

            _data[typeof(T)] = value;
        }

        public void Remove<T>(T value)
        {
            if (!_data.ContainsKey(typeof(T)))
                throw new($"Storage doesn't contains data with type {typeof(T).Name}");

            _data.Remove(typeof(T));
        }
    }
}

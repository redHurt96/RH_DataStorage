using System;
using System.Collections.Generic;
using UnityEngine;

namespace _DataStorage.Logic
{
    public class LocalStorage : MonoBehaviour, IStorage
    {
        public bool IsEmpty => _storage.IsEmpty;

        private readonly Storage _storage = new();

        public void Create<T>(T value) => _storage.Create(value);

        public T Read<T>() => _storage.Read<T>();

        public void UpdateValue<T>(T value) => _storage.UpdateValue(value);

        public void Delete<T>() => _storage.Delete<T>();

        protected IEnumerable<KeyValuePair<Type, object>> GetValues() => 
            _storage.GetValues();
    }
}
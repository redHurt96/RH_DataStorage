using System;
using System.Collections.Generic;

namespace _DataStorage.Logic.Core
{
    public class Storage : IStorage
    {
        private readonly Dictionary<Type, object> _values = new();

        public bool IsEmpty => _values.Count == 0;

        public void Create<T>(T value) =>
            _values.Add(value.GetType(), value);

        public T Read<T>() =>
            (T)_values[typeof(T)];

        public void UpdateValue<T>(T value) =>
            _values[value.GetType()] = value;

        public void Delete<T>() =>
            _values.Remove(typeof(T));

        internal IEnumerable<KeyValuePair<Type, object>> GetValues() => _values;
    }
}
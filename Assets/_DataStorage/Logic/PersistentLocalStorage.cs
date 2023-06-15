using System;
using System.Collections.Generic;
using System.Text;
using RH_Utilities.Attributes;
using UnityEngine;
using static UnityEngine.JsonUtility;

namespace _DataStorage.Logic
{
    public class PersistentLocalStorage : MonoBehaviour, IStorage
    {
        private static readonly Dictionary<Type, Func<object, object>> _primitiveParsers = new()
        {
            [typeof(bool)] = raw => Convert.ToBoolean(raw),
            [typeof(int)] = raw => Convert.ToInt32(raw),
            [typeof(float)] = raw => Convert.ToSingle(raw),
            [typeof(string)] = Convert.ToString,
        };

        [SerializeField, ReadOnly] private string _id;

        private readonly Dictionary<Type, object> _values = new();

        public bool IsEmpty => _values.Count == 0;

        private void Awake()
        {
            if (PlayerPrefs.HasKey(_id))
                Load();
        }

        private void OnDestroy()
        {
            if (_values.Count > 0)
                Save();
        }

        public void Create<T>(T value) => 
            _values.Add(value.GetType(), value);

        public T Read<T>() => 
            (T)_values[typeof(T)];

        public void UpdateValue<T>(T value) => 
            _values[value.GetType()] = value;

        public void Delete<T>() => 
            _values.Remove(typeof(T));

        private void Load()
        {
            string rawData = PlayerPrefs.GetString(_id);
            string[] rawPairs = rawData.Split(";;");

            foreach (string rawPair in rawPairs)
            {
                if (string.IsNullOrEmpty(rawPair))
                    continue;
                
                string[] pair = rawPair.Split(';');
                Type type = Type.GetType(pair[0]);
                object value = _primitiveParsers.ContainsKey(type) 
                    ? _primitiveParsers[type](pair[1]) 
                    : FromJson(pair[1], type);
                
                _values.Add(type, value);
            }
        }

        private void Save()
        {
            StringBuilder builder = new();

            foreach (KeyValuePair<Type,object> pair in _values)
                builder.Append(_primitiveParsers.ContainsKey(pair.Key)
                    ? $"{pair.Key};{pair.Value};;"
                    : $"{pair.Key};{ToJson(pair.Value)};;");

            PlayerPrefs.SetString(_id, builder.ToString());
            PlayerPrefs.Save();
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(GenerateId))]
        private void GenerateId() => 
            _id = Guid.NewGuid().ToString();
#endif
    }
}

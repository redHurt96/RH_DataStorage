using System;
using System.Collections.Generic;
using System.Text;
using RH_Utilities.Attributes;
using UnityEngine;
using static System.Convert;
using static UnityEngine.JsonUtility;
using static UnityEngine.PlayerPrefs;

namespace _DataStorage.Logic
{
    public class PersistentLocalStorage : LocalStorage
    {
        private static readonly Dictionary<Type, Func<object, object>> _primitiveParsers = new()
        {
            [typeof(bool)] = raw => ToBoolean(raw),
            [typeof(int)] = raw => ToInt32(raw),
            [typeof(float)] = raw => ToSingle(raw),
            [typeof(string)] = Convert.ToString,
        };

        [SerializeField, ReadOnly] private string _id;

        private void Awake()
        {
            if (HasKey(_id))
                Load();
        }

        private void OnDestroy()
        {
            if (!IsEmpty)
                Save();
        }

        private void Load()
        {
            string rawData = GetString(_id);
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
                
                Create(value);
            }
        }

        private void Save()
        {
            StringBuilder builder = new();

            foreach (KeyValuePair<Type,object> pair in GetValues())
                builder.Append(_primitiveParsers.ContainsKey(pair.Key)
                    ? $"{pair.Key};{pair.Value};;"
                    : $"{pair.Key};{ToJson(pair.Value)};;");

            SetString(_id, builder.ToString());
            PlayerPrefs.Save();
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(GenerateId))]
        private void GenerateId() => 
            _id = Guid.NewGuid().ToString();
#endif
    }
}

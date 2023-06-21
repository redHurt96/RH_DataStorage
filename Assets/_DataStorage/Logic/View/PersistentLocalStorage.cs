using System;
using System.Collections.Generic;
using System.Text;
using RH_Utilities.Attributes;
using UnityEngine;
using static UnityEngine.JsonUtility;
using static UnityEngine.PlayerPrefs;

namespace _DataStorage.Logic.View
{
    public class PersistentLocalStorage : LocalStorage
    {
        public string Id => _id;
        
        [SerializeField, ReadOnly] private string _id;

        private readonly PrimitivesParser _parser = new();

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
                object value = _parser.ContainsType(type) 
                    ? _parser.Execute(type, pair[1]) 
                    : FromJson(pair[1], type);
                
                Create(value);
            }
        }

        private void Save()
        {
            StringBuilder builder = new();

            foreach (KeyValuePair<Type,object> pair in GetValues())
                builder.Append(_parser.ContainsType(pair.Key)
                    ? $"{pair.Key};{pair.Value};;"
                    : $"{pair.Key};{ToJson(pair.Value)};;");

            SetString(_id, builder.ToString());
            PlayerPrefs.Save();
        }

#if UNITY_EDITOR
        [ContextMenu(nameof(GenerateId))]
        public void GenerateId() => 
            _id = Guid.NewGuid().ToString();
#endif
    }
}

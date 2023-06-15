using _DataStorage.Logic;
using UnityEditor;
using UnityEngine;
using static System.Guid;
using static UnityEngine.Random;

namespace _DataStorage.Sample
{
    public class TestStorageDataProvider : StorageDataProvider
    {
        [SerializeField] private TestData _testData;
        [SerializeField] private int _testSingleInt;
        [SerializeField] private string _testSingleString;
        
        protected override void CreateInitialData(IStorage storage)
        {
            GenerateFields();
            
            storage.Create(_testData);
            storage.Create(_testSingleInt);
            storage.Create(_testSingleString);
        }
        
#if UNITY_EDITOR
        [ContextMenu(nameof(GenerateFields))]
        private void GenerateFields()
        {
            _testData = new()
            {
                TestInt = Range(0, 1000),
                TestString = NewGuid().ToString(),
            };

            _testSingleInt = Range(0, 1000);
            _testSingleString = NewGuid().ToString();
            
            EditorUtility.SetDirty(this);
        }
#endif
    }
}
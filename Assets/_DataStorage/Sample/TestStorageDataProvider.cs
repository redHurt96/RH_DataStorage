using _DataStorage.Logic;
using UnityEngine;

namespace _DataStorage.Sample
{
    public class TestStorageDataProvider : StorageDataProvider
    {
        [SerializeField] private TestData _testData;
        [SerializeField] private int _testSingleInt;
        [SerializeField] private string _testSingleString;
        
        protected override void CreateInitialData(IStorage storage)
        {
            storage.Create(_testData);
            storage.Create(_testSingleInt);
            storage.Create(_testSingleString);
        }
    }
}
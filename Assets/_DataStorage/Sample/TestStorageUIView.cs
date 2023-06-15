using System.Collections;
using _DataStorage.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace _DataStorage.Sample
{
    [RequireComponent(typeof(LocalStorage))]
    public class TestStorageUIView : MonoBehaviour
    {
        [SerializeField] private Text _intField;
        [SerializeField] private Text _stringField;
        [SerializeField] private Text _singleIntField;
        [SerializeField] private Text _singleStringField;
        
        private IEnumerator Start()
        {
            IStorage storage = GetComponent<IStorage>();

            yield return new WaitWhile(() => storage.IsEmpty);

            ParseClass(storage);
            ParsePrimitiveTypes(storage);
        }

        private void ParseClass(IStorage storage)
        {
            TestData data = storage.Read<TestData>();
            _intField.text = data.TestInt.ToString();
            _stringField.text = data.TestString;
        }

        private void ParsePrimitiveTypes(IStorage storage)
        {
            _singleIntField.text = storage.Read<int>().ToString();
            _singleStringField.text = storage.Read<string>();
        }
    }
}
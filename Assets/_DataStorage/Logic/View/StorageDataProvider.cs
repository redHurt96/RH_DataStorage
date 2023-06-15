using _DataStorage.Logic.Core;
using UnityEngine;

namespace _DataStorage.Logic.View
{
    [RequireComponent(typeof(LocalStorage))]
    public abstract class StorageDataProvider : MonoBehaviour
    {
        private void Start()
        {
            IStorage storage = GetComponent<IStorage>();

            if (storage.IsEmpty)
                CreateInitialData(storage);
            
            Destroy(this);
        }

        protected abstract void CreateInitialData(IStorage storage);
    }
}
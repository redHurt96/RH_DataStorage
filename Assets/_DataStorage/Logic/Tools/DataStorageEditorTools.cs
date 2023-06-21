using System.Linq;
using _DataStorage.Logic.View;
using RH_Utilities.Extensions;
using UnityEditor;
using static UnityEngine.Debug;
using static UnityEngine.Object;
using static UnityEngine.PlayerPrefs;

namespace _DataStorage.Logic.Tools
{
    public static class DataStorageEditorTools
    {
        [MenuItem("💾 Data/🧹💾 Clear all")]
        public static void ClearSave() =>
            DeleteAll();

        [MenuItem("💾 Data/📃 Validate scene")]
        public static void ValidatePersistentStoragesInScene()
        {
            PersistentLocalStorage[] storages = FindObjectsOfType<PersistentLocalStorage>();
            
            if (storages.Length != storages.DistinctBy(x => x.Id).Count())
                LogError($"There is collision in storages ids. Please reassign them");
        }

        [MenuItem("💾 Data/✒ Reassign all ids")]
        public static void ReassignAllIds() =>
            FindObjectsOfType<PersistentLocalStorage>()
                .ForEach(x => x.GenerateId());
    }
}
using UnityEditor;
using static UnityEngine.PlayerPrefs;

namespace _DataStorage.Logic.Tools
{
    public static class DataStorageEditorTools
    {
#if UNITY_EDITOR
        [MenuItem("💾 Data/🧹💾 Clear all")]
#endif
        public static void ClearSave() =>
            DeleteAll();
    }
}
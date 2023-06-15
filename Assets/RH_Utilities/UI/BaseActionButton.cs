using UnityEngine;
using UnityEngine.UI;

namespace RH_Utilities.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseActionButton : MonoBehaviour
    {
        private Button _button;

        protected abstract void PerformOnClick();

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PerformOnClick);
        }

        private void OnDestroy() => 
            _button.onClick.RemoveListener(PerformOnClick);
    }
}
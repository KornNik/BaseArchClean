using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    abstract class ButtonEffectExtender : MonoBehaviour
    {
        [SerializeField] private Button _extendedButton;

        private void OnEnable()
        {
            _extendedButton.onClick.AddListener(CustomButtonEffect);
        }
        private void OnDisable()
        {
            _extendedButton.onClick.RemoveListener(CustomButtonEffect);
        }

        protected abstract void CustomButtonEffect();
    }
}

using DG.Tweening;
using UnityEngine;

namespace UI
{
    sealed class RotationLoading : MonoBehaviour
    {
        [SerializeField] private float _rotationTime;

        private IUIEffect _effect;

        private void Awake()
        {
            _effect = new DoTweenRotationEffect(_rotationTime, Ease.Linear,
                transform as RectTransform);
        }

        private void OnEnable()
        {
            _effect.DoEffect();
        }
        private void OnDisable()
        {
            _effect.StopEffect();
        }
    }
}

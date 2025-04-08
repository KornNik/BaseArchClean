using DG.Tweening;
using UnityEngine;

namespace UI
{
    sealed class DoTweenRotationEffect : DotweenUIEffect
    {
        private RectTransform _rotationObject;
        private Vector3 _rotationStep = new Vector3(0f,0f,360);

        public DoTweenRotationEffect(float effectDuration, Ease easeType,
            RectTransform rotationObject) :
            base(effectDuration, easeType)
        {
            _rotationObject = rotationObject;
        }

        protected override Sequence CreateTweenActions(Ease easeType)
        {
            _sequence.Append(_rotationObject.DORotate(_rotationStep, _effectDuration).
                SetEase(easeType).SetLoops(-1, LoopType.Restart).SetRelative());
            return _sequence;
        }
    }
}

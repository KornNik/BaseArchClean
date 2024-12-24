using UnityEngine;
using DG.Tweening;

namespace UI
{
    class FadeElement : DotweenUIEffect
    {
        private readonly CanvasGroup _fadeElement;

        public FadeElement(float fadeDuration, Ease easeType, CanvasGroup fadeElement) : base(fadeDuration, easeType)
        {
            _fadeElement = fadeElement;
        }

        public override Sequence CreateTweenActions(Ease easeType)
        {
            _fadeElement.alpha = 0;
            _sequence.Append(_fadeElement.DOFade(1.0f, _effectDuration).SetEase(easeType));
            return _sequence;
        }
    }
}
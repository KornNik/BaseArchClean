using UnityEngine;
using DG.Tweening;

namespace UI
{
    class FadeElement : DotweenUIEffect
    {
        private CanvasGroup _fadeElement;

        public FadeElement(float fadeDuration, CanvasGroup fadeElement) : base(fadeDuration)
        {
            _effectDuration = fadeDuration;
            _fadeElement = fadeElement;
        }

        public override Sequence CreateTweenActions()
        {
            _fadeElement.alpha = 0;
            _sequence.Append(_fadeElement.DOFade(1.0f, _effectDuration));
            return _sequence;
        }
    }
}
using UnityEngine;
using DG.Tweening;

namespace UI
{
    sealed class BounceElement : DotweenUIEffect
    {
        private Transform _elementTransform;
        private float _effectIntensive;

        public BounceElement(float bounceDuration, float bounceIntensive, Transform elementTransform) : base(bounceDuration)
        {
            _effectDuration = bounceDuration;
            _effectIntensive = bounceIntensive;
            _elementTransform = elementTransform;
        }

        public override Sequence CreateTweenActions()
        {
            _sequence.Append(_elementTransform.DOScale(_effectIntensive, _effectDuration / 2).SetEase(Ease.InBounce));
            _sequence.Append(_elementTransform.DOScale(1f, _effectDuration / 2).SetEase(Ease.Linear));
            return _sequence;
        }
    }
}

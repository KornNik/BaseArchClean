using DG.Tweening;
using System;

namespace UI
{
    abstract class DotweenUIEffect
    {
        protected Sequence _sequence;
        protected float _effectDuration;

        public DotweenUIEffect(float effectDuration)
        {
            _effectDuration = effectDuration;
        }

        public virtual void DoEffect()
        {
            _sequence = DOTween.Sequence();
            CreateTweenActions();
        }
        public virtual void DoEffect(Action actionOnComplete)
        {
            _sequence = DOTween.Sequence();
            CreateTweenActions().OnComplete(() => actionOnComplete.Invoke());
        }
        public abstract Sequence CreateTweenActions();

    }
}


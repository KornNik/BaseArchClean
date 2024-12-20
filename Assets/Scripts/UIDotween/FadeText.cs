using DG.Tweening;
using TMPro;

namespace UI
{
    sealed class FadeText : DotweenUIEffect
    {
        TMP_Text _text;
        public FadeText(float fadeDuration, TMP_Text text) : base(fadeDuration)
        {
            _effectDuration = fadeDuration;
            _text = text;
        }

        public override Sequence CreateTweenActions()
        {
            _text.alpha = 0f;
            _sequence.Append(_text.DOFade(1.0f, _effectDuration));
            return _sequence;
        }
    }
}

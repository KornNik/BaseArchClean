using UnityEngine;
using DG.Tweening;

namespace Behaviours
{
    enum MoveMode
    {
        None = 0,
        Show = 1,
        Hide = 2

    }
    sealed class SettingsPanelTween
    {
        private readonly Vector2 InAnchorMin = new Vector2(0.0f, 0f);
        private readonly Vector2 InAnchorMax = new Vector2(1.0f, 1f);
        private readonly Vector2 OutAnchorMin = new Vector2(0.0f, 1.0f);
        private readonly Vector2 OutAnchorMax = new Vector2(1.0f, 1.0f);

        private readonly Ease _moveEase;
        private readonly RectTransform _moveRoot;
        private readonly float _totalMoveDuration;

        public SettingsPanelTween(RectTransform moveRoot, float totalMoveDuration, Ease moveEase)
        {
            _moveRoot = moveRoot;
            _moveEase = moveEase;
            _totalMoveDuration = totalMoveDuration;
        }

        public void GoToEnd(MoveMode mode)
        {
            switch (mode)
            {
                case MoveMode.Show:
                    _moveRoot.anchorMin = InAnchorMin;
                    _moveRoot.anchorMax = InAnchorMax;
                    break;
                case MoveMode.Hide:
                    _moveRoot.anchorMin = OutAnchorMin;
                    _moveRoot.anchorMax = OutAnchorMax;
                    break;
                default:
                    break;

            }
        }
        public Sequence Move(MoveMode mode, float timeScale)
        {
            Vector2 anchorMin = Vector2.zero;
            Vector2 anchorMax = Vector2.zero;

            switch (mode)
            {
                case MoveMode.Show:
                    anchorMin = InAnchorMin;
                    anchorMax = InAnchorMax;
                    break;
                case MoveMode.Hide:
                    anchorMin = OutAnchorMin;
                    anchorMax = OutAnchorMax;
                    break;
                default:
                    break;
            }

            return DOTween.Sequence()
                .Append(_moveRoot.DOAnchorMin(anchorMin, _totalMoveDuration * timeScale).SetEase(_moveEase))
                .Join(_moveRoot.DOAnchorMax(anchorMax, _totalMoveDuration * timeScale).SetEase(_moveEase));
        }
    }
}

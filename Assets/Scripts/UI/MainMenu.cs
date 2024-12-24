using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Data;
using Helpers;
using Behaviours;

namespace UI
{
    class MainMenu : BaseUI
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _quitGameButton;
        [SerializeField] private LayoutGroup _buttonsGroup;

        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private SettingsPanelTween _panelTween;
        private SequenceSettings _sequenceSettings;
        private DotweenUIEffect _tweenUIEffect;
        private TweenSettings _tweenSettings;

        protected override void Awake()
        {
            base.Awake();
            _tweenSettings = Services.Instance.DatasBundle.ServicesObject.GetData<TweensSettingsBundle>().
                GetTweenSettings(TweenSettingsType.ScreenDefaultSettings);
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();

            _panelTween = new SettingsPanelTween(_rectTransform, _tweenSettings.Duration, _tweenSettings.EaseType);
            _sequenceSettings = new SequenceSettings(_panelTween);
            _tweenUIEffect = new FadeElement(_tweenSettings.Duration, _tweenSettings.EaseType, _canvasGroup);
        }

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartButtonDown);
            _quitGameButton.onClick.AddListener(OnQuitGameButtonDown);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartButtonDown);
            _quitGameButton.onClick.RemoveListener(OnQuitGameButtonDown);
        }

        private void OnDestroy()
        {
            _tweenUIEffect.Dispose();
            _sequenceSettings.Dispose();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();

            _panelTween.GoToEnd(MoveMode.Hide);
            _sequenceSettings.Move(MoveMode.Show);
            _tweenUIEffect.DoEffect();
        }
        public override void Hide()
        {
            _sequenceSettings.Move(MoveMode.Hide).AppendCallback(() => gameObject.SetActive(false));
            HideUI.Invoke();
        }

        private void OnStartButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.LoadLevelState);
        }
        private void OnQuitGameButtonDown()
        {
            Application.Quit();
        }
    }
}
using UnityEngine;
using Helpers;
using Data;

namespace UI
{
    sealed class ScreenFactory
    {
        private Canvas _canvas;
        private GameMenu _gameMenu;
        private MainMenu _mainMenu;
        private PauseMenu _pauseMenu;
        private LoadingScreen _loadingScreen;

        private ScreenToType _screenToType;


        public ScreenFactory()
        {
            _screenToType = new ScreenToType();
            var resources = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.Canvas);
            _canvas = GameObject.Instantiate(resources, Vector3.one, Quaternion.identity).GetComponent<Canvas>();
        }

        public GameMenu GetGameMenu()
        {
            if (_gameMenu == null)
            {
                _gameMenu  = ReturnScreen<GameMenu>();
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                _mainMenu = ReturnScreen<MainMenu>();
            }
            return _mainMenu;
        }
        public PauseMenu GetPauseMenu()
        {
            if (_pauseMenu == null)
            {
                _pauseMenu = ReturnScreen<PauseMenu>();
            }
            return _pauseMenu;
        }
        public LoadingScreen GetLoadingScreen()
        {
            if (_loadingScreen == null)
            {
                _loadingScreen = ReturnScreen<LoadingScreen>();
            }
            return _loadingScreen;
        }

        private TScreen ReturnScreen<TScreen>()
        {
            var screenRes = Services.Instance.DataResourcePrefabs.ServicesObject.
                GetScreenPrefab(_screenToType.Provide<TScreen>());
            var screen = GameObject.Instantiate(screenRes, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<TScreen>();
            return screen;
        }
    }
}
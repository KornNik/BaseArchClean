using UnityEngine;
using Helpers;
using Helpers.Extensions;
using Helpers.AssetsPath;

namespace UI
{
    sealed class ScreenFactory
    {
        private Canvas _canvas;
        private GameMenu _gameMenu;
        private MainMenu _mainMenu;
        private PauseMenu _pauseMenu;
        private LoadingScreen _loadingScreen;


        public ScreenFactory()
        {
            var resources = CustomResources.Load<Canvas>(ScreenAssetPath.Screens[ScreenTypes.Canvas].Screen);
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity);
        }

        public GameMenu GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var resources = CustomResources.Load<GameMenu>(ScreenAssetPath.Screens[ScreenTypes.GameMenu].Screen);
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var resources = CustomResources.Load<MainMenu>(ScreenAssetPath.Screens[ScreenTypes.MainMenu].Screen);
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _mainMenu;
        }
        public PauseMenu GetPauseMenu()
        {
            if (_pauseMenu == null)
            {
                var resources = CustomResources.Load<PauseMenu>(ScreenAssetPath.Screens[ScreenTypes.PauseMenu].Screen);
                _pauseMenu = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _pauseMenu;
        }
        public LoadingScreen GetLoadingScreen()
        {
            if (_loadingScreen == null)
            {
                var resources = CustomResources.Load<LoadingScreen>(ScreenAssetPath.Screens[ScreenTypes.LoadingScreen].Screen);
                _loadingScreen = Object.Instantiate(resources, _canvas.transform.position, Quaternion.identity, _canvas.transform);
            }
            return _loadingScreen;
        }
    }
}
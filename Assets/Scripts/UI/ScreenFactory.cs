using UnityEngine;
using Helpers;
using Data;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
            var resources = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.Canvas);
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity).GetComponent<Canvas>();
        }

        public GameMenu GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.GameMenu);
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<GameMenu>();
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.MainMenu);
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<MainMenu>();
            }
            return _mainMenu;
        }
        public PauseMenu GetPauseMenu()
        {
            if (_pauseMenu == null)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.PauseMenu);
                _pauseMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<PauseMenu>();
            }
            return _pauseMenu;
        }
        public LoadingScreen GetLoadingScreen()
        {
            if (_loadingScreen == null)
            {
                var resources = Services.Instance.DataResourcePrefabs.ServicesObject.
                    GetScreenPrefab(ScreenTypes.LoadingScreen);
                _loadingScreen = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<LoadingScreen>();
            }
            return _loadingScreen;
        }

        private async UniTask<TScreen> ReturnScreen<TScreen>()
        {
            var screen = LoadScreenObject<TScreen>
                    (Services.Instance.AddressablesReference.ServicesObject.
                    GetScreenRef(ScreenTypes.LoadingScreen));
            return await screen;
        }

        private async UniTask<TScreen> LoadScreenObject<TScreen>(AssetReference assetReference)
        {
            var loadablePrefab = assetReference;
            var handle = Addressables.InstantiateAsync(loadablePrefab);
            await handle.ToUniTask();
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var neededScreen = handle.Result.GetComponent<TScreen>();
                return  neededScreen;
            }
            throw new System.NullReferenceException();
        }
    }
}
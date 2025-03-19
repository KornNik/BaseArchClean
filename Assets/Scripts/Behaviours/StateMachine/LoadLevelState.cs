using Helpers;
using System;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class LoadLevelState : BaseState
    {
        private ILevelLoader _levelLoader;

        public LoadLevelState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }

        public override void EnterState()
        {
            base.EnterState();
            LoadAll().Forget();
        }
        private async UniTaskVoid LoadAll()
        {
            await LoadTask(LoadLevelBehaviours);
            await LoadTask(StartGameState);
        }

        private async UniTask LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await UniTask.Yield();
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelByIndex(0);
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
    }
}
